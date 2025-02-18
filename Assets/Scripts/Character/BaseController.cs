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
        dir = dir * moveSpeed;
        rb.velocity = dir;
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

    /// <summary>
    /// ������Ʈ�� �ʱ�ȭ �����ִ� �޼���
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
    /// ������ �ʱ�ȭ �����ִ� �޼���
    /// </summary>
    protected virtual void InitializeVariable()
    {
        moveDir = Vector2.zero;
        lookDir = Vector2.zero;
    }
}
