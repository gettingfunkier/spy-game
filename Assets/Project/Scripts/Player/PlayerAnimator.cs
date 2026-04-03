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
            if (movement.isLookingRight)
            {
                animator.SetTrigger("CheckEarpieceRight");
                // Debug.Log("R");
            }
            else if (movement.isLookingLeft)
            {
                animator.SetTrigger("CheckEarpieceLeft");
                // Debug.Log("L");
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

    void StartSprint()
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

    void StartJump()
    {
        if (isGrounded && jumpPressed)
        {

        }
    }

    void StartFall()
    {
        if (!isGrounded && body.linearVelocity.y < 0f)
        {

        }
    }
}