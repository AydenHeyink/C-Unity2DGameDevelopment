using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] float delayDestroy = 1f;
    bool hasPackage;
    private void Start()
    {
        hasPackage= false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            Debug.Log("Package picked up!");
            Destroy(collision.gameObject, delayDestroy);
        }
        if (collision.tag == "Customer" && hasPackage)
        {           
            Debug.Log("Package delivered!");
            hasPackage= false;     
        }
    }
}
