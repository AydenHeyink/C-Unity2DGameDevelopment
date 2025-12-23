using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    SpriteRenderer mySpriteRenderer;

    void Start()
    {
        myRigidbody= GetComponent<Rigidbody2D>();
        mySpriteRenderer= GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        if (mySpriteRenderer.flipY == false) 
        { 
            mySpriteRenderer.flipY = true;
        }
        else
        {
            mySpriteRenderer.flipY = false;
        }
    }
}
