using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // state machine
    enum PlayerState { Idle, Sprint, Jump, Fall };
    PlayerState state;

    // scene instanced objects
    [SerializeField] Rigidbody2D body;

    // player inputs
    public float horizontalInput;
    private float verticalInput;

    // movement properties
    public float moveSpeed;
    public float jumpForce;
    public int maxJumps = 2;
    private int jumpCount = 0;
    public float terminalVelocity = -10;

    // variables
    public bool isGrounded;
    public bool isMoving;
    public bool isMovingRight;
    public bool isMovingLeft;
    public bool isJumping;
    public bool isFalling;
    public bool isLookingRight = true;
    public bool isLookingLeft;
    public bool isSprintingRight = false;
    public bool isSprintingLeft = false;
    public bool jumpPressed;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckInput();
        SelectState();

        Sprint();
        Jump();
    }

    void FixedUpdate()
    {
        CheckLookDirection();
        CheckMovementDirection();
        CheckSprintDirection();
        CheckTerminalVelocity();

        isGrounded = IsGrounded();
        isFalling = IsFalling();
    }

    void CheckInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        isMoving = Mathf.Abs(horizontalInput) > 0.1;
        jumpPressed = Input.GetButtonDown("Jump");
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    }

    bool IsFalling()
    {
        return body.linearVelocity.y < 0;
    }
    
    void CheckLookDirection()
    {
        if (horizontalInput > 0)
        {
            isLookingRight = true;
            isLookingLeft = false;
        }
        else if (horizontalInput < 0)
        {
            isLookingRight = false;
            isLookingLeft  =  true;
        }
    }

    void CheckMovementDirection()
    {
        if (horizontalInput > 0)
        {
            isMovingRight = true;
            isMovingLeft  = false;
        }
        else if (horizontalInput < 0)
        {
            isMovingRight = false;
            isMovingLeft  = true;
        }
        else
        {
            isMovingRight = false;
            isMovingLeft  = false;
        }
    }

    void CheckSprintDirection()
    {
        if (isGrounded)
        {
            isSprintingRight = horizontalInput > 0f;
            isSprintingLeft  = horizontalInput < 0f;
        }
        else
        {
            isSprintingRight = false;
            isSprintingLeft  = false;
        }
    }

    void CheckTerminalVelocity()
    {
        if (body.linearVelocity.y < terminalVelocity)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, terminalVelocity);
        }
    }

    void SelectState()
    {
        if (isGrounded)
        {
            if (!isMoving)
            {
                state = PlayerState.Idle;
            }
            else
            {
                state = PlayerState.Sprint;
            }
        }
        else
        {
            if (isJumping)
            {
                state = PlayerState.Jump;
            }
            else if (isFalling)
            {
                state = PlayerState.Fall;
            }
        }
    }

    void StartIdle()
    {
        switch (isLookingRight)
        {
            case true:

                break;
            case false:

                break;
        }
    }

    void StartMoving()
    {
        var key = (isLookingRight, isSprintingRight);
        switch (key)
        {
            case (false, false):
                // Debug.Log("SprintLeftToLeft");
                break;

            case (false, true):
                // Debug.Log("SprintLeftToRight");
                break;

            case (true, false):
                // Debug.Log("SprintRightToLeft");
                break;

            case (true, true):
                // Debug.Log("SprintRightToRight");
                break;
        }
    }

    void StartAirborne()
    {
        if (isGrounded && jumpPressed)
        {

        }
        else if (isFalling)
        {
            
        }
    }

    void Sprint()
    {
        body.linearVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);
    }

    void Jump()
    {
        if (jumpPressed && isGrounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }
}