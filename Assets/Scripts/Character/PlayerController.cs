using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera mainCam;

    #region Unity Event Method
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        mainCam = Camera.main;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    #endregion

    protected override void InitializeComponent()
    {
        base.InitializeComponent();

        if (!TryGetComponent<BoxCollider2D>(out boxCol))
        {
            boxCol = gameObject.AddComponent<BoxCollider2D>();
            boxCol.offset = new Vector2(0, -0.2148886f);
            boxCol.size = new Vector2(1, 1.429777f);
        }
    }

    protected override void InitializeVariable()
    {
        base.InitializeVariable();
        moveSpeed = 5f;
    }

    private void OnMove(InputValue inputValue)
    {
        moveDir = inputValue.Get<Vector2>();
        moveDir.Normalize();
    }

    private void OnLook(InputValue inputValue)
    {
        Vector2 mousePos = inputValue.Get<Vector2>();
        mousePos = mainCam.ScreenToWorldPoint(mousePos);
        lookDir = mousePos - (Vector2)transform.position;

        if (lookDir.magnitude < 0.9f)
        {
            lookDir = Vector2.zero;
        }
        else
        {
            lookDir.Normalize();
        }
    }
}
