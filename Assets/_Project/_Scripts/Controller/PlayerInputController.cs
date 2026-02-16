using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        Vector2 input;

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        MoveInput = Vector2.ClampMagnitude(input, 1f);
        JumpPressed = Input.GetButtonDown("Jump");
    }

    public void ConsumeJump()
    {
        JumpPressed = false;
    }
}
