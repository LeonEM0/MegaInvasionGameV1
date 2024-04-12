using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{

    

    [Header("Bullet Properties")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject projectilePrefab2;
    [SerializeField] Transform bulletSpawnPoint;
    SimpleCharacterController character;


    [Header("audio")] 
   [SerializeField] AudioClip gunshot;
    [SerializeField] AudioSource audioSource;

    private Ray ray; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        character = GetComponentInParent<SimpleCharacterController>();
        
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Input.GetMouseButton(1))
        {
            Shoot();
        }
    }

    // Update is called once per frame

    private void Shoot()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        Quaternion rotation = Quaternion.identity;
        
        if (Physics.Raycast(ray, out hit) && !hit.collider.CompareTag("Collectable") &&!hit.collider.CompareTag("Bullet"))
        {
            Vector3 direction = hit.point - bulletSpawnPoint.position;
            rotation = Quaternion.LookRotation(direction);
        }
        else
        {
            rotation = Quaternion.LookRotation(ray.direction);

        }


        AudioManagerSingleton.Instance.PlaySound(gunshot);
        Instantiate(projectilePrefab, bulletSpawnPoint.position,rotation);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 1000);
    }





}

