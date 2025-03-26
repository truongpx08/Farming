using UnityEngine;

public class PlayerMovementView : MonoBehaviour
{
    private PlayerSharedComponents sharedComponents;

    public void Initialize(PlayerSharedComponents components)
    {
        sharedComponents = components;
    }

    public void Move(Vector3 velocity)
    {
        sharedComponents.Rb.velocity = velocity;
    }
}