using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;

    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;

    [SerializeField] float upperBoundPadding;
    [SerializeField] float downBoundPadding;

    InputAction moveAction;
    Vector2 moveInput;
    PlayerInput playerInput;

    Vector2 minBounds;
    Vector2 maxBounds;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    private void Start()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }
    // Update is called once per frame
    void Update()
    {
        MovePlayer();    
    }

    void MovePlayer()
    {
        Vector3 moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, 
            minBounds.x + leftBoundPadding, 
            maxBounds.x - rightBoundPadding);
        
        newPos.y = Mathf.Clamp(newPos.y, 
            minBounds.y + downBoundPadding, 
            maxBounds.y - upperBoundPadding);

        transform.position = newPos;
    }
}
