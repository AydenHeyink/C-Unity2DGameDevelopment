using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked up package");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }
        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();

        }

        //Debug.Log("What the heck was that?");
    }
}
