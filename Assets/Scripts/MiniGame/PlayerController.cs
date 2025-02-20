using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniGame
{
    public class PlayerController : MonoBehaviour
    {
        private float forwardSpeed;
        private float jumpForce;
        private bool isJump;
        private bool isDead;
        public bool IsDead => isDead;

        private GameManager gameManager;

        private Rigidbody2D rb;
        private Animator animator;

        private void Awake()
        {
            forwardSpeed = 3f;
            jumpForce = 5f;
            isJump = false;
            isDead = false;

            if (!TryGetComponent<Rigidbody2D>(out rb))
            {
                rb = gameObject.AddComponent<Rigidbody2D>();
            }
            rb.gravityScale = 1f;

            animator = GetComponentInChildren<Animator>();
            animator.SetBool("IsMove", true);
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isJump = true;
            }
        }

        private void FixedUpdate()
        {
            Vector3 velocity = rb.velocity;
            velocity.x = forwardSpeed;

            if (isJump)
            {
                velocity.y += jumpForce;
                isJump = false;
            }

            rb.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                isDead = true;
                gameManager.GameOver();
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameManager.AddScore();
            }
        }
    }
}
