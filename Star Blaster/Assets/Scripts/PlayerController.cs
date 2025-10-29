using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    InputAction moveAction;
    Vector2 moveInput;
    PlayerInput playerInput;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();    
    }

    void MovePlayer()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        Vector3 moveVector = new Vector3(moveInput.x, moveInput.y, 0);
        transform.position += moveVector * moveSpeed * Time.deltaTime;

        Debug.Log("Move Input: " + moveInput);
    }
}
