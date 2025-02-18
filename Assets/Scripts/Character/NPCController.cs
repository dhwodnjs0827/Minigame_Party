using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : BaseController
{
    // 테스트용
    public PlayerController player;

    #region Field
    private CircleCollider2D circleCol;

    private delegate void NPCAction();
    private NPCAction action;

    private float patrolTime;
    private float patrolElapsedTime;

    private bool isMovingLeft;
    #endregion

    #region Unity Event Method
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        action = LookPlayer;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        action = Patrol;
    }
    #endregion

    protected override void InitializeComponent()
    {
        base.InitializeComponent();

        rb.bodyType = RigidbodyType2D.Kinematic;

        if (!TryGetComponent<BoxCollider2D>(out boxCol))
        {
            boxCol = gameObject.AddComponent<BoxCollider2D>();
            boxCol.offset = new Vector2(0, -0.2148886f);
            boxCol.size = new Vector2(1, 1.429777f);
        }

        if (!TryGetComponent<CircleCollider2D>(out circleCol))
        {
            circleCol = gameObject.AddComponent<CircleCollider2D>();
            circleCol.radius = 1f;
        }
    }

    protected override void InitializeVariable()
    {
        base.InitializeVariable();
        moveSpeed = 1f;
        moveDir = Vector2.left;
        patrolTime = 3f;
        patrolElapsedTime = 0f;
        isMovingLeft = true;

        action = Patrol;
    }

    protected override void HandleAction()
    {
        base.HandleAction();
        action();
    }

    private void Patrol()
    {
        patrolElapsedTime += Time.deltaTime;
        moveDir = isMovingLeft ? Vector2.left : Vector2.right;

        if (patrolElapsedTime >= patrolTime)
        {
            isMovingLeft = !isMovingLeft;
            patrolElapsedTime = 0f;
        }

        lookDir = (Vector2)transform.position + moveDir * 10f;
        lookDir.Normalize();
    }

    private void LookPlayer()
    {
        moveDir = Vector2.zero;
        lookDir = (player.transform.position - transform.position).normalized;
    }
}
