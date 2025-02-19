using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private PlayerController player;

    public Door triggerObject;

    private Sprite leftSprite;
    private Sprite rightSprite;

    private bool isActive;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        player = null;

        leftSprite = Resources.Load<Sprite>("Sprites/Items/lever_left");
        rightSprite = Resources.Load<Sprite>("Sprites/Items/lever_right");

        isActive = false;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = leftSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 트리거 활성화
            player = collision.GetComponent<PlayerController>();
            player.CanInteract = true;
            EventManager.Instance.onPlayerInteract += ToggleLever;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 트리거 비활성화
            player.CanInteract = false;
            player = null;
            EventManager.Instance.onPlayerInteract -= ToggleLever;
        }
    }

    public void ToggleLever()
    {
        isActive = !isActive;
        spriteRenderer.sprite = isActive ? rightSprite : leftSprite;
        triggerObject.Toggle();
    }
}
