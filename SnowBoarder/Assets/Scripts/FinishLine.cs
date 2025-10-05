using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float invokeWaitTime = 1.5f;
    [SerializeField] AudioSource aSource;
    bool hasFinished;

    private void Start()
    {
        hasFinished= false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !hasFinished)
        {
            aSource.Play();
            hasFinished = true;
            Invoke("ReloadScene", invokeWaitTime);
            
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
