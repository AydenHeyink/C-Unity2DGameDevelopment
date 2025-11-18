using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;
    [SerializeField] TextMeshProUGUI text;

    public static ScoreKeeper instance;

    private void Awake()
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

    private void Update()
    {
        text.text = currentScore.ToString();
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ChangeScore(int score)
    {
        currentScore += score;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
