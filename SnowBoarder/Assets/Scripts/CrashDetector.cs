using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] AudioSource aSource;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashParticles.Play();
            aSource.Play();
            Invoke("StartOver", 2f);
        }
    }

    public void StartOver()
    {
        SceneManager.LoadScene("Level1");
    }
}
