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

        private Rigidbody2D rb;
        private Animator animator;

        private void Awake()
        {
            forwardSpeed = 3f;
            jumpForce = 6f;

            if (!TryGetComponent<Rigidbody2D>(out rb))
            {
                rb = gameObject.AddComponent<Rigidbody2D>();
            }
            rb.gravityScale = 1f;

            animator = GetComponentInChildren<Animator>();
            animator.SetBool("IsMove", true);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
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
    }
}
