using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float torqueAmount = 1f;
    
    InputAction moveAction;
    Rigidbody2D myRigidbody;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector;
        moveVector = moveAction.ReadValue<Vector2>();

        if (moveVector.x < 0)
        {
            myRigidbody.AddTorque(torqueAmount);
        }

        else if (moveVector.x > 0)
        {
            myRigidbody.AddTorque(-torqueAmount);
        }
    }
}
