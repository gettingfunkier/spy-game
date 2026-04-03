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
        if (randomValue <= 2 && !isMoving && isGrounded)
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