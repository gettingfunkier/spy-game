using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // state machine
    enum PlayerState { Idle, Moving, Airborne };
    PlayerState state;
    bool stateComplete;

    // scene instanced objects
    [SerializeField] Rigidbody2D body;
    [SerializeField] private Animator animator;

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
    public bool isMoving;
    public bool isJumping;
    public bool isGrounded;
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

        if (stateComplete)
        {
            SelectState();
            stateComplete = false;
        }

        UpdateState();

        Sprint();
        Jump();
    }

    void FixedUpdate()
    {
        CheckLookDirection();
        CheckSprintDirection();
        CheckTerminalVelocity();
        RareIdleAnimation();

        isGrounded = IsGrounded();
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
                StartIdle();
            }
            else
            {
                state = PlayerState.Moving;
                StartMoving();
            }
        }
        else
        {
            state = PlayerState.Airborne;
            // StartAirborne();
        }
    }

    void UpdateState()
    {
        switch (state)
        {
            case PlayerState.Idle:
                UpdateIdle();
                break;

            case PlayerState.Moving:
                UpdateMoving();
                break;
                
            case PlayerState.Airborne:
                UpdateAirborne();
                break;
        }
    }

    void UpdateIdle()
    {
        if (horizontalInput != 0)
        {
            stateComplete = true;
        }
    }

    void UpdateMoving()
    {
        if (!isGrounded || horizontalInput == 0)
        {
            stateComplete = true;
        }
    }

    void UpdateAirborne()
    {
        if (isGrounded)
        {
            stateComplete = true;
        }
    }

    void StartIdle()
    {
        switch (isLookingRight)
        {
            case true:
                animator.Play("IdleRight");
                break;
            case false:
                animator.Play("IdleLeft");
                break;
        }
    }

    void StartMoving()
    {
        var key = (isLookingRight, isSprintingRight);
        switch (key)
        {
            case (false, false):
                Debug.Log("SprintLeftToLeft");
                break;

            case (false, true):
                Debug.Log("SprintLeftToRight");
                break;

            case (true, false):
                Debug.Log("SprintRightToLeft");
                break;

            case (true, true):
                Debug.Log("SprintRightToRight");
                break;
        }
    }

    void Sprint()
    {
        body.linearVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);

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

    void RareIdleAnimation()
    {
        int randomValue = Random.Range(0, 1000);
        // Debug.Log(randomValue);
        if (randomValue <= 2)
        {
            if (isLookingRight)
            {
                animator.SetTrigger("CheckEarpieceRight");
                // Debug.Log("R");
            }
            else if (isLookingLeft)
            {
                animator.SetTrigger("CheckEarpieceLeft");
                // Debug.Log("L");
            }
        }
    }
}