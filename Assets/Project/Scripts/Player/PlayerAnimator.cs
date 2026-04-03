using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement movement;
    public SpriteRenderer spriteRenderer;

    void Start ()
    {
        
    }

    void Update ()
    {

    }

    void RareIdleAnimation()
    {
        int randomValue = Random.Range(0, 1000);
        // Debug.Log(randomValue);
        if (randomValue <= 2 && !movement.isMoving && movement.isGrounded)
        {

        }
    }

    void StartIdle()
    {
        switch (movement.isLookingRight)
        {
            case true:

                break;
            case false:

                break;
        }
    }

    void StartSprint()
    {
        
    }

    void StartJump()
    {
        if (movement.isGrounded && movement.jumpPressed)
        {

        }
    }

    void StartFall()
    {
        if (!movement.isGrounded && movement.body.linearVelocity.y < 0f)
        {

        }
    }
}