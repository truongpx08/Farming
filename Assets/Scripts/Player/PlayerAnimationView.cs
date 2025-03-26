using UnityEngine;

public class PlayerAnimationView : MonoBehaviour
{
    private Animator animator;

    public void Initialize(PlayerSharedComponents components)
    {
        animator = components.Animator;
    }

    public void SetMovementState(bool isMoving)
    {
        animator.Play(isMoving ? "Walk" : "Idle");
    }
}