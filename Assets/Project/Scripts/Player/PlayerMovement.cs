using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField]
    Rigidbody2D body;
    public float moveSpeed = 5f;
    public float horizontalInput;
    public float terminalVelocity = -10;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0.1)
        {
            body.linearVelocity = new Vector2(horizontalInput * moveSpeed, body.linearVelocity.y);
        }
        else
        {
            body.linearVelocity = new Vector2(0, body.linearVelocity.y);
        }
    }
}