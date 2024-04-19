using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;
using System.IO;

public class LoadGameScript : MonoBehaviour
{
    public GameObject playerGameObject;
    //Method to load saved game data from a JSON file
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + "/savedGameData.json";

        if (File.Exists(filePath))
        {

            string json = File.ReadAllText(filePath);

            GameData loadedGameData = JsonUtility.FromJson<GameData>(json);

            Debug.Log("Loaded game data: " + loadedGameData);
        }
        else
        {
            Debug.LogWarning("No saved game data found.");
        }
    }
    public void LoadPlayerLocation()
    {
        string filePath = Application.persistentDataPath + "/playerLocation.json";
        string json = File.ReadAllText(filePath);

        Vector3 playerPosition = JsonUtility.FromJson<Vector3>(json);

        playerGameObject.transform.position = playerPosition;
    }

}

[System.Serializable]
public class GameData
{
    public int playerLevel;
}


/*
 * 
 * Add This to the Save Game Script:

    public void SavePlayerLocation()
    {
        Vector3 playerPosition = playerGameObject.transform.position;

        string json = JsonUtility.ToJson(playerPosition);

        string filePath = Application.persistentDataPath + "/playerLocation.json";
        File.WriteAllText(filePath, json);
    }*/
