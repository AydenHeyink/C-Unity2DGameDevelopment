using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;

    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 minBounds;
    Vector2 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        InitRounds();
    }

    // Update is called once per frame
    void Update()
    {
        NewMethod();
    }

    void InitRounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    private void NewMethod()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void Move()
    {
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x, maxBounds.x);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y, maxBounds.y);
        transform.position = newPos;
    }

    //void OnMove(InputValue value)
    //{
    //    rawInput = value.Get<Vector2>();
    //}
}
