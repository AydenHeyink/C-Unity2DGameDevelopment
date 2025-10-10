using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float runSpeed = 8f;

    private Vector2 moveInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        moveAction = new InputAction(type: InputActionType.Value, binding: "<Keyboard>/w");
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        moveAction.Enable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x, 0);
        moveInput = moveAction.ReadValue<Vector2>();
        rb.velocity = moveInput * moveSpeed;
    }
}
