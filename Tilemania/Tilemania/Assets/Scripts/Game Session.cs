using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives;

    private void Awake()
    {
        // Create our Singleton
        int numberGameSessions = FindObjectsByType<GameSession>(FindObjectsSortMode.None).Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1) 
        {
            TakeLife(); 
        }
        else
        {
            ResetGameSession(); 
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentIndexScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndexScene);
    }

    void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    // When player dies, do things
    // reduce number of lives
    // if we have no lives left then restart the whole game

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
