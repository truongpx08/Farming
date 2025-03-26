using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private PlayerModel model;
    private PlayerSharedComponents sharedComponents;
    [SerializeField] private PlayerMovementView movementView;

    public void Initialize(PlayerModel playerModel, PlayerSharedComponents components)
    {
        model = playerModel;
        sharedComponents = components;
        movementView.Initialize(components);
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (!sharedComponents) return;
        Vector3 moveDirection = sharedComponents.InputHandler.GetMoveDirection();
        movementView.Move(moveDirection * model.MoveSpeed);
    }
}