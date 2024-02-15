using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playScene : MonoBehaviour
{
    public static void LoadScenebyIndex(int index)
    {
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
