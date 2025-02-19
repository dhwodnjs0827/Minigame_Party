using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Move(Vector2 velocity)
    {
        animator.SetBool("IsMove", velocity.magnitude > 0.5f);
    }

    public void Damage()
    {
        animator.SetBool("IsDamage", true);
    }

    public void InvincibilityEnd()
    {
        animator.SetBool("IsDamage", false);
    }
}
