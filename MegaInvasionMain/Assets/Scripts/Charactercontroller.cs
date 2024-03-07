using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SimpleCharacterController : MonoBehaviour
{
    //camera
    public CinemachineVirtualCamera vCam;
    public float adsFov = 40;
    public float hipFov;
    public float currentFov;


    public float speed = 150f; //Movement speed
    public float runspeed = 50f;
    public float currentspeed;
    public float rotationSpeed = 200f; //Rotation speed
    public float jumpForce = 200f;
    [SerializeField] Animator animator;
    public bool isJumping = false;
    public bool isGrounded = true;
    public float jumpSpeed;

    private Rigidbody rb;
    //aiming
    public Transform aimPos;
    [SerializeField] float aimSmoothSpeed =20;
    [SerializeField] LayerMask aimMask;


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

        Vector2 screenCentre = new Vector2(Screen.width/2,Screen.height/2);
        Ray ray = Camera.main.ScreenPointToRay(screenCentre);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime);
        }



        MoveCharacter(horizontalInput, verticalInput);
       // RotateCharacter(horizontalInput);

        UpdateAnimation();


        //if (Input.GetButtonDown("Jump"))
        //{
        //    Jump();
        //}

        Jump();
       // Debug.Log("HORIZONTAL"+horizontalInput+"VERTICAL"+verticalInput); print coordinates
       

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
            
            Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
            rb.MovePosition(transform.position + transform.TransformDirection(movement));

        }
       

      
    }
  
 
    void RotateCharacter(float horizontal)
    {
        float rotation = horizontal * rotationSpeed * Time.deltaTime;
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * rotation);
        rb.MoveRotation(rb.rotation * deltaRotation);
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
        else if(Input.GetButtonUp("Jump"))
        {
            animator.SetBool("IsJumpingAnim", false);
        
        }


        
            


    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Plane")
        {
            isGrounded = true;
        }
       /* else if(collision.gameObject.name != "Plane")
        {
            animator.SetBool("IsJumpingAnim", false);
            animator.SetBool("IsFallingAnim", false);
            animator.SetBool("IsGroundedAnim", false);
        }
       */
    }
}
