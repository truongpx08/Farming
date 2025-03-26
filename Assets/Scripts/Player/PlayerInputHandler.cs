using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection;

    private void FixedUpdate()
    {
        HandleMoveInput();
    }

    private void HandleMoveInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector3(horizontal, 0, vertical).normalized;
    }

    public Vector3 GetMoveDirection()
    {
        return moveDirection;
    }
}