using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasConnected = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!coinPickupSFX)
            {
                Debug.Log("Sound effect");
            }
            else
            {
                AudioSource.PlayClipAtPoint(coinPickupSFX, this.transform.position);
            }
            wasConnected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
    }
}
