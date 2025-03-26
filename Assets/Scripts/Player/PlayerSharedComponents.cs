using UnityEngine;

public class PlayerSharedComponents : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public Rigidbody Rb => this.rb;
    [SerializeField] private PlayerInputHandler inputHandler;
    public PlayerInputHandler InputHandler => this.inputHandler;
    [SerializeField] private Animator animator;
    public Animator Animator => this.animator;
}