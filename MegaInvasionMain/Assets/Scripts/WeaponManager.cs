using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{



    [Header("Bullet Properties")]
    List<GameObject> projectiles = new List<GameObject>();
    public int bulletnumber;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] GameObject projectilePrefab2;
    [SerializeField] GameObject projectilePrefab3;
    [SerializeField] GameObject shield;

    [SerializeField] Transform bulletSpawnPoint;
    SimpleCharacterController character;


    [Header("audio")] 
   [SerializeField] AudioClip gunshot;
   [SerializeField] AudioClip shieldsound;
    [SerializeField] AudioSource audioSource;

    private Ray ray; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        character = GetComponentInParent<SimpleCharacterController>();

        projectiles.Add(projectilePrefab);
        projectiles.Add(projectilePrefab2);
        projectiles.Add(projectilePrefab3);

        
    }
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.E))
        {
            ChangeTypeofBullet();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            AudioManagerSingleton.Instance.PlaySound(shieldsound);
            ActivateShield(Quaternion.identity);
        }    

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

        Instantiate(projectiles[0], bulletSpawnPoint.position, rotation);



    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(ray.origin, ray.origin + ray.direction * 1000);
    }

    public void ChangeTypeofBullet()
    {
       
        bulletnumber++;


        if (bulletnumber > 2)
        {
            bulletnumber = 0;
            projectiles[0] = projectilePrefab;
        }
        else
        {
            projectiles[0] = projectiles[bulletnumber]; 
        }
    }

    public void ActivateShield(Quaternion rotation)
    {
        Instantiate(shield, bulletSpawnPoint.position, rotation);

    }



}

