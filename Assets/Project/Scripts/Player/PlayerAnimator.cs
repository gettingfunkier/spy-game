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
        spriteRenderer.flipX = movement.isLookingLeft;

        if (!movement.isGrounded)
        {
            // animator.Play("Lily_Jump");
            // animator.Play("Lily_Fall");
        }
        else if (movement.isSprinting)
        {
            animator.Play("Lily_Sprint");
        }
        else
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Lily_CheckEarpiece") 
                && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f) return;
            if (!RareIdleAnimation()) animator.Play("Lily_Idle");
        }
    }

    bool RareIdleAnimation()
    {
        int randomValue = Random.Range(0, 5000);
        // Debug.Log(randomValue);
        if (randomValue <= 2 && !movement.isMoving && movement.isGrounded)
        {
            animator.Play("Lily_CheckEarpiece");
            return true;
        }
        return false;
    }
}