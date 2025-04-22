using UnityEngine;

public class FollowBone : MonoBehaviour
{
    // Tham chiếu đến xương của Player
    public Transform playerBone;

    // Độ lệch vị trí (nếu cần)
    public Vector3 positionOffset;

    // Độ lệch xoay (nếu cần)
    public Vector3 rotationOffset;

    void Update()
    {
        if (playerBone != null)
        {
            // Cập nhật vị trí của đối tượng theo xương của Player
            transform.position = playerBone.position + positionOffset;

            // Cập nhật xoay của đối tượng theo xương của Player
            transform.rotation = playerBone.rotation * Quaternion.Euler(rotationOffset);
        }
        else
        {
            Debug.LogWarning("Player bone is not assigned.");
        }
    }
}