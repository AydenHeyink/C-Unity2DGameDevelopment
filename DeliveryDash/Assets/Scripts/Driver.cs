using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] float currentSpeed = 5f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 7.5f;
    [SerializeField] float regularSpeed = 5f;

    [SerializeField] TMP_Text boost_text;

    private void Start()
    {
        boost_text.gameObject.SetActive(false);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boost_text.gameObject.SetActive(true);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("WorldCollision"))
        {
            currentSpeed = regularSpeed;
            boost_text.gameObject.SetActive(false);
        }
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
