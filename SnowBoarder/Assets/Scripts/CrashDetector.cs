using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            crashParticles.Play();
            Invoke("StartOver", 2f);
        }
    }

    void StartOver()
    {
        SceneManager.LoadScene("Level1");
    }
}
