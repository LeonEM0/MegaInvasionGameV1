using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        Debug.Log("Door Opened");
        transform.Rotate(0, 90, 0);
    }
    public void Interact()
    {
        Open();
    }


}
