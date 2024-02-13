using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public delegate void DelSaludo(); 

    PlayerControls controls;

    public static Vector2 movementInput;
    public static Vector2 turnInput;
    public static bool isAimingInput = false;

    private void Awake()
    {
        
        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Player.Move.performed += Move; // what youre suscribing are the methods
        controls.Player.Move.canceled += Move;  //when you click on an event youre activating a sequence of events

        controls.Player.Turn.performed += Turn;
        controls.Player.Turn.canceled += Turn;

        controls.Player.Aiming.performed += ctx => isAimingInput = true;
        controls.Player.Aiming.canceled += ctx => isAimingInput = false;

        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Move.performed -= Move;
        controls.Player.Turn.performed -= Turn;

        controls.Player.Turn.performed -= Turn;
        controls.Player.Turn.canceled -= Turn;
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void Turn(InputAction.CallbackContext ctx)
    {
        turnInput = ctx.ReadValue<Vector2>();
    }
    private void Aim(InputAction.CallbackContext ctx)
    {
        isAimingInput = ctx.ReadValue<bool>();
        Debug.Log("Aim:"+isAimingInput);
    }
}
// The delegates are used to call events 
// also the delegates need to have the same signature
// the delegate needs to be of the same type of fuction either VOID OR WITH RETURN
// Se usan para pasar como argumento un metodo a otro metodo


// Ejemplo EventHandler metodo que va a ser ejecutado por el delegado

// GetKeyDown == Performed when the user is doing the action holding key
// GetKeyUp == Cancelled when the user release the key
// Getkey == Started when the user presses the key 