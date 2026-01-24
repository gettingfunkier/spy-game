using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] Rigidbody2D body;
    [SerializeField] private Animator animator;

    private float horizontalInput;
    private float verticalInput;

    public float moveSpeed;
    public float jumpForce;

    public bool isMoving;
    public bool isJumping;
    public bool isGrounded;
    public bool jumpPressed;

    public int maxJumps = 2;
    private int jumpCount = 0;

    bool isSprintingRight = false;
    bool isSprintingLeft = false;

    public float terminalVelocity = -10;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        isMoving = Mathf.Abs(horizontalInput) > 0.1;
        jumpPressed = Input.GetButtonDown("Jump");

        Sprint();
        Jump();

        Debug.Log($"Input: V {Input.GetAxis("Vertical")}, H {Input.GetAxis("Horizontal")}");
    }

    void FixedUpdate()
    {
        isGrounded = IsGrounded();
    }

    void Sprint()
    {
        if (isMoving)
        {
            isSprintingLeft  = horizontalInput < 0f;
            isSprintingRight = horizontalInput > 0f;

            body.linearVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);
        }
        else
        {
            isSprintingRight = false;
            isSprintingLeft  = false;

            body.linearVelocity = new Vector2(0, body.linearVelocity.y);
        }

        animator.SetBool("isSprintingRight", isSprintingRight);
        animator.SetBool("isSprintingLeft", isSprintingLeft);
    }

    void Jump()
    {
        if (jumpPressed && isGrounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    }
}