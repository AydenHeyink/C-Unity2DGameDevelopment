using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32();
    [SerializeField] Color32 noPackageColor = new Color32();

    [SerializeField] float delayDestroy = 1f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        hasPackage= false;
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !hasPackage)
        {
            spriteRenderer.color = hasPackageColor;
            hasPackage = true;
            Debug.Log("Package picked up!");
            Destroy(collision.gameObject, delayDestroy);
        }
        if (collision.tag == "Customer" && hasPackage)
        {           
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package delivered!");
            hasPackage= false;     
        }
    }
}
