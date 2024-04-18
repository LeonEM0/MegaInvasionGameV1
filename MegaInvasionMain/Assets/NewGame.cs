using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGamePlay : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
