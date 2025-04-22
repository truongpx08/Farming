using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private PlayerAnimationView animationView;
    private PlayerSharedComponents sharedComponents;

    public void Initialize(PlayerSharedComponents components)
    {
        sharedComponents = components;
        animationView.Initialize(components);
    }

    private void Update()
    {
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        Vector3 moveDirection = sharedComponents.InputHandler.MoveDirection;
        bool isMoving = moveDirection.magnitude > 0.1f;
        animationView.SetMovementState(isMoving);
    }
}