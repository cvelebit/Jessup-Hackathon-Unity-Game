using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MainMenu : MonoBehaviour
{
    public GameObject starterWeapon;
    public GameObject HomeMenu;
    public GameObject Credits;
    public GameObject Controls;

    public void Awake()
    {
        GlobalVariables.Score = 0;
        GlobalVariables.DamageModifier = 0;
        GlobalVariables.Speed = 5;
        GlobalVariables.CurrentWeapon = starterWeapon;
    }

    public void StartGame()
    {
        Debug.Log("button pressed");
        SceneManager.LoadScene("Scenes/StartingLevel");
    }

    public void OpenCredits()
    {
        HomeMenu.SetActive(false);
        Credits.SetActive(true);
    }

    public void BackFromCredits()
    {
        Credits.SetActive(false);
        HomeMenu.SetActive(true);
    }

    public void OpenControls()
    {
        HomeMenu.SetActive(false);
        Controls.SetActive(true);
    }

    public void BackFromControls()
    {
        Controls.SetActive(false);
        HomeMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("button pressed");

        Application.Quit();
    }
}
