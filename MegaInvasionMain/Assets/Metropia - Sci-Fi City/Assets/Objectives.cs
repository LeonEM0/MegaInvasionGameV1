using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    public Text objectiveText;

    private string mainObjective = "Main Objective: Make your way to the Main Complex to receive further instructions";

    void Start()
    {
        if (objectiveText == null)
        {
            Debug.LogError("No reference to the UI Text Element provided for displaying objectives!");
            return;
        }

        DisplayObjective(mainObjective);
    }

    public void DisplayObjective(string objective)
    {
        objectiveText.text = objective;
    }
}
