using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public Rigidbody2D body;
    public float moveSpeed = 5f;
    public float horizontalInput;
    public float terminalVelocity = -10;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        float y = body.linearVelocity.y;
        if (y < terminalVelocity) y = terminalVelocity;
        body.linearVelocity = new Vector2(horizontalInput * moveSpeed, y);
    }
    
}