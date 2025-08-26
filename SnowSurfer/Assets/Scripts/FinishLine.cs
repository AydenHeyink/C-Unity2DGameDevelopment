using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        
        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("The player has won!");
        }
    }
}
