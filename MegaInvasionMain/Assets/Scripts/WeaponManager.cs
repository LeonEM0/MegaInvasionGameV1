using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]

    [SerializeField] float fireRate;
    float fireRateTimer;
    [SerializeField] bool semiAuto;
    

    [Header("Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
     SimpleCharacterController character;

    [Header("audio")] 
   [SerializeField] AudioClip gunshot;
    [SerializeField] AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        fireRateTimer = fireRate;
        character = GetComponentInParent<SimpleCharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldFire()) Fire();
    }
    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;

    }
    void Fire()
    {
        fireRateTimer = 0;
        bulletSpawnPoint.LookAt(character.aimPos);
        audioSource.PlayOneShot(gunshot);
        for(int i = 0; i< bulletsPerShot;i++)
        {
            GameObject currentBullet = Instantiate(bullet,bulletSpawnPoint.position,bulletSpawnPoint.rotation);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(bulletSpawnPoint.forward * bulletVelocity,ForceMode.Impulse);
        }

        Debug.Log("Fire");

        
    }



}
