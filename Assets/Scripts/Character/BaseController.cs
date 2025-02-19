using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    #region Field
    #region Variables
    protected Vector2 moveDir;
    protected Vector2 lookDir;
    #endregion

    #region Components
    protected Rigidbody2D rb;
    protected BoxCollider2D boxCol;
    protected SpriteRenderer characterRenderer;
    protected StatHandler statHandler;
    protected AnimationHandler animationHandler;
    #endregion
    #endregion

    #region Method
    #region Unity Event Method
    protected virtual void Awake()
    {
        InitializeVariable();
        InitializeComponent();
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

    #region Initailize Method
    /// <summary>
    /// ������ �ʱ�ȭ �����ִ� �޼���
    /// </summary>
    protected virtual void InitializeVariable()
    {
        moveDir = Vector2.zero;
        lookDir = Vector2.zero;
    }

    /// <summary>
    /// ������Ʈ�� �ʱ�ȭ �����ִ� �޼���
    /// </summary>
    protected virtual void InitializeComponent()
    {
        IntializeRigidbocy2D();
        InitializeBoxCollider2D();
        InitializeStatHandler();
        InitializeAnimationHandler();
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    protected virtual void IntializeRigidbocy2D()
    {
        if (!TryGetComponent<Rigidbody2D>(out rb))
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }
    
    protected virtual void InitializeBoxCollider2D()
    {
        if (!TryGetComponent<BoxCollider2D>(out boxCol))
        {
            boxCol = gameObject.AddComponent<BoxCollider2D>();
        }
    }

    protected virtual void InitializeStatHandler()
    {
        if (!TryGetComponent<StatHandler>(out statHandler))
        {
            statHandler = gameObject.AddComponent<StatHandler>();
        }
    }

    protected virtual void InitializeAnimationHandler()
    {
        if (!TryGetComponent<AnimationHandler>(out animationHandler))
        {
            animationHandler = gameObject.AddComponent<AnimationHandler>();
        }
    }
    #endregion

    /// <summary>
    /// ĳ������ �ൿ�� ó���ϴ� �޼���
    /// </summary>
    protected virtual void HandleAction()
    {

    }

    /// <summary>
    /// �̵� ����� �̵� �ӵ��� ���� ���� ĳ������ �ӵ��� ����
    /// </summary>
    /// <param name="dir">ĳ������ �̵� ����</param>
    private void Move(Vector2 dir)
    {
        dir = dir * statHandler.Speed;
        rb.velocity = dir;
        animationHandler.Move(dir);
    }

    /// <summary>
    /// �ٶ󺸴� ��ǥ�� x���� y�� ������ ������ ���� �������� �ٶ󺸸� ��������, ������ �ٶ󺸸� �������� ĳ���͸� �����´�.
    /// </summary>
    /// <param name="dir">�ٶ󺸴� ��ǥ ����</param>
    private void Rotate(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(angle) > 90f;
    }
    #endregion
}
