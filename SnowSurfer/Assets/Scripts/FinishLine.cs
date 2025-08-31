using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float timeDelay = 2.5f;
    [SerializeField] ParticleSystem finishParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");
        
        if (collision.gameObject.layer == layerIndex)
        {
            Debug.Log("Win");
            finishParticles.Play();
            Invoke("ReloadScene", timeDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
