using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    #region Field
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCol;
    protected SpriteRenderer characterRenderer;

    protected Vector2 moveDir;
    protected Vector2 lookDir;

    protected float moveSpeed;
    #endregion

    #region Unity Event Method
    protected virtual void Awake()
    {
        InitializeComponent();
        InitializeVariable();
    }

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDir);
    }

    protected virtual void FixedUpdate()
    {
        Move(moveDir);
    }
    #endregion

    /// <summary>
    /// 캐릭터의 행동을 처리하는 메서드
    /// </summary>
    protected virtual void HandleAction()
    {

    }

    /// <summary>
    /// 이동 방향과 이동 속도를 곱한 값을 캐릭터의 속도로 설정
    /// </summary>
    /// <param name="dir">캐릭터의 이동 방향</param>
    private void Move(Vector2 dir)
    {
        dir = dir * moveSpeed;
        rb.velocity = dir;
    }

    /// <summary>
    /// 바라보는 좌표의 x값과 y값 사이의 각도를 구해 오른쪽을 바라보면 오른쪽을, 왼쪽을 바라보면 왼쪽으로 캐릭터를 뒤집는다.
    /// </summary>
    /// <param name="dir">바라보는 좌표 벡터</param>
    private void Rotate(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(angle) > 90f;
    }

    /// <summary>
    /// 컴포넌트를 초기화 시켜주는 메서드
    /// </summary>
    protected virtual void InitializeComponent()
    {
        if (!TryGetComponent<Rigidbody2D>(out rb))
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }

        characterRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    /// <summary>
    /// 변수를 초기화 시켜주는 메서드
    /// </summary>
    protected virtual void InitializeVariable()
    {
        moveDir = Vector2.zero;
        lookDir = Vector2.zero;
    }
}
