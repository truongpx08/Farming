using UnityEngine;

public class PlayerController : TruongSingleton<PlayerController>
{
    [SerializeField] private PlayerMovementController movementController;
    [SerializeField] private PlayerRotationController rotationController;
    [SerializeField] private PlayerAnimationController animationController;
    [SerializeField] private PlayerSharedComponents sharedComponents;
    [SerializeField] private PlayerInputHandler inputHandler;
    public PlayerInputHandler InputHandler => this.inputHandler;
    [SerializeField] private PlayerCurrentItemController currentItemController;
    public PlayerCurrentItemController CurrentItemController => this.currentItemController;
    [SerializeField] private PlayerBones bones;
    public PlayerBones Bones => this.bones;

    public void Initialize(PlayerModel playerModel)
    {
        movementController.Initialize(playerModel, sharedComponents);
        rotationController.Initialize(playerModel, sharedComponents);
        animationController.Initialize(sharedComponents);
    }
}