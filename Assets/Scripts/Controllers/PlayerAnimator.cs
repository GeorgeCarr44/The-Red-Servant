using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerMovementController playerMovementController;

    private void Start()
    {
        playerMovementController = this.GetComponent<PlayerMovementController>();
        animator = this.GetComponent<Animator>();
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        if (animator != null)
        {
            animator.SetFloat("Horizontal", playerMovementController.MovementDirection.x);
            animator.SetFloat("Vertical", playerMovementController.MovementDirection.y);
            animator.SetFloat("Speed", playerMovementController.MovementDirection.sqrMagnitude);
        }
    }
}
