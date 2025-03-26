using UnityEngine;

public class PlayerRotationView : MonoBehaviour
{
    private PlayerSharedComponents sharedComponents;

    public void Initialize(PlayerSharedComponents components)
    {
        sharedComponents = components;
    }

    public void Rotate(Quaternion targetRotation, float rotateSpeed)
    {
        sharedComponents.Rb.rotation = Quaternion.Lerp(
            sharedComponents.Rb.rotation, 
            targetRotation, 
            rotateSpeed * Time.fixedDeltaTime
        );
    }
}