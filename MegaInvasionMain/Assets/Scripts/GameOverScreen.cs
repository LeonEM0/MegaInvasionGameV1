using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject player;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState= CursorLockMode.Locked;
        }
    }
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SaulScene");
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void MainMenu()
    {
       SceneManager.LoadScene("MenuScene");
    }
}
