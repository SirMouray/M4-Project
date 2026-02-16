using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSystem : MonoBehaviour
{
    [Header("Jump Settings")]

    [SerializeField] private float _jumpForce = 5f;

    [Header("Consecutive Jumps")]

    [SerializeField] private int _maxJumps = 1;

    [SerializeField] private GroundCheck _groundCheck;

    private Rigidbody _rb;
    private int _jumpCount;

    public bool IsGrounded => _groundCheck != null && _groundCheck.IsGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ResetJumpIfGrounded();
    }

    public void Jump()
    {
        if (_jumpCount >= _maxJumps) return;

        Vector3 velocity = _rb.velocity;
        velocity.y = 0f;
        _rb.velocity = velocity;

        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
        _jumpCount++;
    }

    private void ResetJumpIfGrounded()
    {
        if (IsGrounded && _jumpCount > 0)
            _jumpCount = 0;
    }
}
