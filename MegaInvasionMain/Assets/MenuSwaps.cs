using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSwaps : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject SettingsCanvas;
    public GameObject LoadGameCanvas;
    public GameObject QuitGameCanvas;

    void Start()
    {
        MainMenuCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        LoadGameCanvas.SetActive(false);
        QuitGameCanvas.SetActive(false);
    }

    public void Settings()
    {
        MainMenuCanvas.SetActive(false);
        LoadGameCanvas.SetActive(false);
        QuitGameCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }

    public void LoadGame()
    {
        MainMenuCanvas.SetActive(false);
        LoadGameCanvas.SetActive(true);
        SettingsCanvas.SetActive(false);
        QuitGameCanvas.SetActive(false);
    }

    public void BackToMainMenu()
    {
        MainMenuCanvas.SetActive(true);
        LoadGameCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        QuitGameCanvas.SetActive(false);
    }

    public void QuitGameScreen()
    {
        MainMenuCanvas.SetActive(false);
        LoadGameCanvas.SetActive(false);
        SettingsCanvas.SetActive(false);
        QuitGameCanvas.SetActive(true);
    }
}
