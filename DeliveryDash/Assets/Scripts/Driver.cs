using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 7.5f;
    [SerializeField] float regularSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed = regularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0f;
        float steer = 0f;

        if (Keyboard.current.upArrowKey.isPressed)
        {
            move = 1f;
        }
        
        else if (Keyboard.current.downArrowKey.isPressed)
        {
            move = -1f;
        }
        
        else if (Keyboard.current.leftArrowKey.isPressed)
        {
            steer = 2f;
        }
        
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            steer = -2f;
        }

        float moveAmount = move * currentSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
        
    }
}
