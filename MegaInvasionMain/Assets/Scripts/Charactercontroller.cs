using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.IO;

public class SimpleCharacterController : MonoBehaviour
{
    public int health = 100;
    //camera
    public CinemachineVirtualCamera vCam;
    public float adsFov = 40;
    public float hipFov;
    public float currentFov;


    public float speed = 150f; //Movement speed
    public float runspeed = 50f;
    public float currentspeed;
    public float rotationSpeed = 20f; //Rotation speed
    public float jumpForce = 200f;
    [SerializeField] Animator animator;
    public bool isJumping = false;
    public bool isGrounded = true;
    public float jumpSpeed;
    public float boostTimer;
    public bool isBoosting;

    private Rigidbody rb;
    //aiming
   // public Transform aimPos;
    [SerializeField] float aimSmoothSpeed =20;
    [SerializeField] LayerMask aimMask;
    public float rayDistance = 30f; // variable to see the path of the ray to shoot bullets


    void Start()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currentFov, fovsmoothSpeed * Time.deltaTime);
/*
        Vector2 screenCentre = new Vector2(Screen.width/2,Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCentre);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        }
*/



        MoveCharacter(horizontalInput, verticalInput);
       // RotateCharacter(horizontalInput);

        UpdateAnimation();


        //if (Input.GetButtonDown("Jump"))
        //{
        //    Jump();
        //}

        Jump();
        // Debug.Log("HORIZONTAL"+horizontalInput+"VERTICAL"+verticalInput); print coordinates

        if (isBoosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer <= 3)
            {
                speed = 20;
                boostTimer = 0;
                isBoosting = false;
            }
        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            int speedboost = 10;
            //isBoosting = true;
            speed = speed + speedboost;
            Debug.Log(speed);

        }
        TakeDamage(other);
    }

void MoveCharacter(float horizontal, float vertical)
    {
       


        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentspeed = speed + runspeed;
            Vector3 movement = new Vector3(horizontal, 0f, vertical) * currentspeed * Time.deltaTime;
            rb.MovePosition(transform.position + transform.TransformDirection(movement));
        }
        else
        {
            RotateCharacter(horizontal);
            Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
            rb.MovePosition(transform.position + transform.TransformDirection(movement));

        }
       
      //  Debug.Log("HORIZONTAL"+horizontal);
       // Debug.Log("VERTICAL"+vertical);



    }

    void TakeDamage(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log(health);
        }
    }



    void RotateCharacter(float vertical)
    {
        float rotation = vertical;

        // Check if the S key is pressed


        if (Input.GetKey(KeyCode.F) && Input.GetKeyDown(KeyCode.S))
        {
         
         
        
                // Rotate 180 degrees
                rotation = 180f;
                this.transform.Rotate(transform.rotation.x, rotation, transform.rotation.z);
           
            
        }

    }

    //void Jump()
    //{
    //    rb.AddForce(Vector2.up * jumpForce * 1.5f);

    //}

    public void UpdateAnimation()
    {
        animator.SetFloat("xSpeed", InputManager.movementInput.x);
        animator.SetFloat("zSpeed", InputManager.movementInput.y);
      
    }
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            isGrounded = false;
            animator.SetBool("IsJumpingAnim", true);
            animator.SetBool("IsFallingAnim",true);
            animator.SetBool("IsGroundedAnim",true);
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
              
          
        }
     


        
            


    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plane"))//piso
        {
            isGrounded = true;
            animator.SetBool("IsJumpingAnim", false);
            animator.SetBool("IsFallingAnim", false);
            animator.SetBool("IsGroundedAnim", false);


        }

        if (collision.gameObject.CompareTag("Trampoline"))//trampoline
        {

            isGrounded = false;
            animator.SetBool("IsJumpingAnim", true);
            animator.SetBool("IsFallingAnim", true);
            animator.SetBool("IsGroundedAnim", true);

        }
     




        /* else if(collision.gameObject.name != "Plane")
         {
             animator.SetBool("IsJumpingAnim", false);
             animator.SetBool("IsFallingAnim", false);
             animator.SetBool("IsGroundedAnim", false);
         }
        */
    }

    

    /* private void OnCollisionExit(Collision collision)
     {
         if(collision.gameObject.CompareTag("Trampoline"))
         {
             animator.SetBool("IsJumpingAnim",false);
             animator.SetBool("IsFallingAnim", false);
             animator.SetBool("IsGroundedAnim", false);
         }
     }
    */



}
// Jump fixed*
// fix the navmeshagentsurface *
// fix the shooting
// animation of the player when hes rotating 
// audio manager 
// add object pooling for the bullets player and enemies