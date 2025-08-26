using UnityEngine;

public class CrashDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("The player has lost");
        }
    }
}
