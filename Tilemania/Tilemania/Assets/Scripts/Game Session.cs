using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    private void Awake()
    {
        // Create our Singleton
        int numberGameSessions = FindObjectOfType<GameSession>(FindObjectsSortMode.None).Length;

        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
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
