using UnityEngine;

public class Delivery : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package"))
        {
            Debug.Log("Picked up package");
        }
        if (collision.CompareTag("Customer"))
        {
            Debug.Log("Delivered package");
        }

        //Debug.Log("What the heck was that?");
    }
}
