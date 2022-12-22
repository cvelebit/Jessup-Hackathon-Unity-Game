using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    public Text FinalScore;

    public GameObject GameOverScreen;

    private HitPointsManager playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HitPointsManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.HealthRatio <= 0)
        {
            DisplayFinalScore();
        }
    }

    private void DisplayFinalScore()
    {
        GameOverScreen.SetActive(true);
        FinalScore.text = "Final Score: " + GlobalVariables.Score;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
