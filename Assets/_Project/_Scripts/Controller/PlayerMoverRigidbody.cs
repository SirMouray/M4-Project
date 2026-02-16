using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverRigidbody : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float rotationSpeed = 10f;

    [Header("References")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private PlayerInputController input;
    [SerializeField] private JumpSystem jumpSystem;
    [SerializeField] private AnimatorManager animatorManager;

    private Rigidbody _rb;

    public float VerticalVelocity => _rb.velocity.y;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        _rb.interpolation = RigidbodyInterpolation.Interpolate;
        _rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }
    private void Update()
    {
        HandleJump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputDir = input.MoveInput;

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDir = camForward * inputDir.y + camRight * inputDir.x;

        Vector3 velocity = moveDir * moveSpeed;
        velocity.y = _rb.velocity.y;
        _rb.velocity = velocity;

        if (moveDir.sqrMagnitude <= 0.01f)
        {
            _rb.angularVelocity = Vector3.zero;
            return;
        }
        if (moveDir.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);

            transform.rotation = Quaternion.Slerp(
                transform.rotation, targetRot,
                rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void HandleJump()
    {
        if (input.JumpPressed)
        {
            jumpSystem.Jump();
            input.ConsumeJump();
        }
    }

    //private void UpdateAnimator()
    //{
    //    animatorManager.UpdateLocomotion(input.MoveInput.x, GetSpeedPercent());
    //    animatorManager.UpdateJumpState(jumpSystem.IsGrounded, _rb.velocity.y);
    //}

    public float GetSpeedPercent()
    {
        Vector3 flatVel = _rb.velocity;
        flatVel.y = 0;
        return Mathf.Clamp01(flatVel.magnitude / moveSpeed);
    }
}
