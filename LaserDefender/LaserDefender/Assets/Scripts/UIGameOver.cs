using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    public static UIGameOver instance;

    public UIGameOver GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore().ToString();
    }
}
