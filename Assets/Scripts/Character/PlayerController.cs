using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    #region Field
    private Camera mainCam;

    private EventManager eventManager;

    public bool CanInteract { get; set; }
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
        mainCam = Camera.main;
        eventManager = EventManager.Instance;
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

    #region Initialize Method
    protected override void InitializeVariable()
    {
        base.InitializeVariable();
        moveSpeed = 5f;
        CanInteract = false;
    }
    protected override void InitializeBoxCollider2D()
    {
        base.InitializeBoxCollider2D();
        boxCol.offset = new Vector2(0, -0.2148886f);
        boxCol.size = new Vector2(1, 1.429777f);
    }
    #endregion

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

    private void OnInteract(InputValue inputValue)
    {
        if (CanInteract)
        {
            eventManager.onPlayerInteract?.Invoke();
        }
    }
    #endregion
}
