using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Door : MonoBehaviour, ITrigger
{
    private PlayerController player;

    private Sprite closedSprite;
    private Sprite openSprite;

    private bool isClosed;

    private BoxCollider2D boxCol;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        player = null;

        closedSprite = Resources.Load<Sprite>("Sprites/Maps/doors_leaf_closed");
        openSprite = Resources.Load<Sprite>("Sprites/Maps/doors_leaf_open");

        isClosed = true;

        if (!TryGetComponent<BoxCollider2D>(out boxCol))
        {
            gameObject.AddComponent<BoxCollider2D>();
        }
        boxCol.isTrigger = false;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = closedSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 트리거 활성화
            player = collision.GetComponent<PlayerController>();
            player.CanInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 트리거 비활성화
            player.CanInteract = false;
            player = null;
        }
    }

    public void Toggle()
    {
        isClosed = !isClosed;
        boxCol.isTrigger = !isClosed;
        spriteRenderer.sprite = isClosed ? closedSprite : openSprite;
    }
}
