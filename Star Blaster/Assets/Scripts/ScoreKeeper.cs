using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    private int currentScore;
    [SerializeField] TextMeshProUGUI text;

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
