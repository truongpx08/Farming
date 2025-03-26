using UnityEngine;

public class PlayerRotationController : MonoBehaviour
{
    private PlayerModel model;
    private PlayerSharedComponents sharedComponents;
    [SerializeField] private PlayerRotationView rotationView;

    public void Initialize(PlayerModel playerModel, PlayerSharedComponents components)
    {
        model = playerModel;
        sharedComponents = components;
        rotationView.Initialize(components);
    }

    private void FixedUpdate()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (!sharedComponents) return;
        Vector3 moveDirection = sharedComponents.InputHandler.GetMoveDirection();

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            rotationView.Rotate(targetRotation, model.RotateSpeed);
        }
    }
}