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
}