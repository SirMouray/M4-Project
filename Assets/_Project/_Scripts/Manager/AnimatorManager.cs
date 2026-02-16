using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AnimatorManager : MonoBehaviour
{
    [SerializeField] private Animator animator;

    int horizontalHash;
    int verticalHash;
    int groundedHash;
    int verticalVelocityHash;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        horizontalHash = Animator.StringToHash("Horizontal");
        verticalHash = Animator.StringToHash("Vertical");
        groundedHash = Animator.StringToHash("IsGrounded");
        verticalVelocityHash = Animator.StringToHash("VerticalVelocity");
    }
    public void UpdateLocomotion(float horizontalInput, float speedPercent)
    {
        animator.SetFloat(horizontalHash, horizontalInput, 0.1f, Time.deltaTime);
        animator.SetFloat(verticalHash, speedPercent, 0.1f, Time.deltaTime);
    }

    public void UpdateJumpState(bool isGrounded, float verticalVelocity)
    {
        animator.SetBool(groundedHash, isGrounded);
        animator.SetFloat(verticalVelocityHash, verticalVelocity);
    }
}
