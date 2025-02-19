using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    #region Field
    private Camera mainCam;
    private EventManager eventManager;

    public GameObject CurRoom
    {
        get; set;
    }
    public bool CanInteract
    {
        get; set;
    }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            CurRoom = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Room") && collision.gameObject != CurRoom)
        {
            CameraController cam = mainCam.GetComponent<CameraController>();
            cam.ChangeCameraPos(CurRoom.transform.position);
        }
    }
    #endregion

    #region Initialize Method
    protected override void InitializeVariable()
    {
        base.InitializeVariable();
        CurRoom = null;
        CanInteract = false;
    }
    protected override void InitializeBoxCollider2D()
    {
        base.InitializeBoxCollider2D();
        boxCol.offset = new Vector2(0, -0.2148886f);
        boxCol.size = new Vector2(1, 1.429777f);
    }

    protected override void InitializeStatHandler()
    {
        base.InitializeStatHandler();
        statHandler.Health = 10;
        statHandler.Speed = 5f;
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
