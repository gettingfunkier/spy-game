using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] Rigidbody2D body;
    [SerializeField] private Animator animator;

    public float moveSpeed = 5f;
    public float horizontalInput;
    public float terminalVelocity = -10;

    bool isSprintingRight = false;
    bool isSprintingLeft = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        bool isMoving = Mathf.Abs(horizontalInput) > 0.1;

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

        Debug.Log($"Input: {Input.GetAxis("Horizontal")}");
    }
}