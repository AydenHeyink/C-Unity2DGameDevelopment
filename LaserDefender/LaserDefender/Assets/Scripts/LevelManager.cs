using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad("SampleScene", 1));
    }

    public void LoadDeath()
    {
        StartCoroutine(WaitAndLoad("DeadScene", 1));
    }

    public void LoadStart()
    {
        StartCoroutine(WaitAndLoad("StartScene", 1));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
