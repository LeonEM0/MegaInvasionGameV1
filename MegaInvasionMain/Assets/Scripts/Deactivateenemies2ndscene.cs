using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivateenemies2ndscene : MonoBehaviour
{
    public GameObject enemies2scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider activaenemigo)
    {
        if (activaenemigo.CompareTag("Player"))
        {
            enemies2scene.SetActive(true);
            Debug.Log("activa enemigos");
        }
    }




}
