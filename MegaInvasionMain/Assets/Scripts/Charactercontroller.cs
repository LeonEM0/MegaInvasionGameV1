using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCharacterController : MonoBehaviour
{
    public float speed = 150f; //Movement speed
    public float rotationSpeed = 200f; //Rotation speed
    public float jumpForce = 200f;
    [SerializeField] Animator animator;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        MoveCharacter(horizontalInput, verticalInput);

        RotateCharacter(horizontalInput);

        UpdateAnimation();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));
    }

    void RotateCharacter(float horizontal)
    {
        float rotation = horizontal * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce * 1.5f);
        
    }

    public void UpdateAnimation()
    {
        animator.SetFloat("xSpeed", InputManager.movementInput.x);
        animator.SetFloat("zSpeed", InputManager.movementInput.y);
      
    }
}
