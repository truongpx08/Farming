using UnityEngine;

public class PlayerController : TruongSingleton<PlayerController>
{
    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerRotationController rotationController;
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private PlayerSharedComponents sharedComponents;

    public void Initialize(PlayerModel playerModel)
    {
        movementController.Initialize(playerModel, sharedComponents);
        rotationController.Initialize(playerModel, sharedComponents);
        animationController.Initialize(sharedComponents);
    }
}