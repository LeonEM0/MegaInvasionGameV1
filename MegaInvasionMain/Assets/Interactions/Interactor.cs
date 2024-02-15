using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable
{
    public void Interact();
}
public class Interactor : MonoBehaviour
{
    private IInteractable _currentInteractable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        // Interact with other objects
        other.GetComponent<Door>().Open();
    }
    public void Interact()
    {
       // _currentInteractable_interact;
    }
}
