using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetection : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Floor");

        if (collision.gameObject.layer == layerIndex)
        {
            crashParticle.Play();
            Debug.Log("CrashDetection");
            Invoke("ReloadScene", 2.5f );
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
