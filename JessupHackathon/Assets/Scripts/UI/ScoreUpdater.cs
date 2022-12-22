using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    private Text scoreText;
    private int currentScore;
void Start()
{
    scoreText = GetComponent<Text>();
    UpdateScore();
}

    // Update is called once per frame
    void Update()
    {
        if (currentScore != GlobalVariables.Score)
        {
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        currentScore = GlobalVariables.Score;
        scoreText.text = "Score: " + currentScore;
    }
}
