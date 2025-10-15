using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;

    private Rigidbody2D rb;
    private Animator myAnimator;
    private CapsuleCollider2D myBodyCollider;
    float gravityScaleAtStart;
    BoxCollider2D myFeetCollider;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpSpeed = 20f;
    [SerializeField] private float climbSpeed = 3f;

    private Vector2 moveInput;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rb.gravityScale;

        // Movement input
        moveAction = new InputAction(type: InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");
        moveAction.Enable();

        // Jump input
        jumpAction = new InputAction(type: InputActionType.Button, binding: "<Keyboard>/space");
        jumpAction.performed += ctx => OnJump(ctx);
        jumpAction.Enable();
    }

    void Update()
    {
        // Read movement input
        moveInput = moveAction.ReadValue<Vector2>();

        Run();
        FlipSprite();
        OnClimb();
    }

    void FixedUpdate()
    {
        // Apply horizontal velocity in FixedUpdate
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    void Run()
    {
        // Horizontal velocity is handled in FixedUpdate, just update animator here
        bool hasHorizontalSpeed = Mathf.Abs(moveInput.x) > 0.01f;
        myAnimator.SetBool("isRunning", hasHorizontalSpeed);
    }

    void FlipSprite()
    {
        if (Mathf.Abs(moveInput.x) > 0.01f)
        {
            transform.localScale = new Vector2(Mathf.Sign(moveInput.x), 1f);
        }
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;

        if (context.ReadValue<float>() > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); // set jump
            myAnimator.SetTrigger("Jump");
        }
    }

    void OnClimb()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }
        rb.gravityScale = 0;

        rb.velocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);

        bool hasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", hasVerticalSpeed);
    }
}
