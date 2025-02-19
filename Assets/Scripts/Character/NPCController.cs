using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCController : BaseController
{
    #region Field
    // 테스트용
    public PlayerController player;
    #region Variables
    private delegate void NPCAction();
    private NPCAction action;

    private float playerTriggerRadius;

    private float patrolTime;
    private float patrolElapsedTime;

    private bool isMovingLeft;
    #endregion

    #region Component
    private CircleCollider2D circleCol;
    [SerializeField] private TextMeshProUGUI text;
    #endregion
    #endregion

    #region Method
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
        if (collision.CompareTag("Player"))
        {
            // 이벤트 트리거 활성화
            action = LookPlayer;
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 이벤트 트리거 비활성화
            action = Patrol;
            text.gameObject.SetActive(false);
        }
    }
    #endregion

    #region Initialize Method
    protected override void InitializeVariable()
    {
        base.InitializeVariable();

        moveSpeed = 1f;
        moveDir = Vector2.left;
        playerTriggerRadius = 1f;
        patrolTime = 3f;
        patrolElapsedTime = 0f;
        isMovingLeft = true;

        action = Patrol;
    }

    protected override void InitializeComponent()
    {
        base.InitializeComponent();
        InitializeCircleCollider2D();
    }

    protected override void IntializeRigidbocy2D()
    {
        base.IntializeRigidbocy2D();
    }

    protected override void InitializeBoxCollider2D()
    {
        base.InitializeBoxCollider2D();
        boxCol.excludeLayers = 1 << LayerMask.NameToLayer("Player");
    }

    private void InitializeCircleCollider2D()
    {
        if (!TryGetComponent<CircleCollider2D>(out circleCol))
        {
            circleCol = gameObject.AddComponent<CircleCollider2D>();
        }
        circleCol.radius = playerTriggerRadius;
    }
    #endregion

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
    #endregion
}
