using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRayCast : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    float dist;
    [SerializeField] float raygizmo = 30f;
    public float detect_player = 20;
    public Transform turrethead;
    public GameObject projectile;
    [SerializeField] private Transform spawnpoint;
    public float fireRate, nextFire;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /* RaycastHit hit;

         Ray ray = new Ray(transform.position, player.transform.position *Time.deltaTime);
         Debug.DrawRay(ray.origin, ray.direction * raygizmo, Color.green); //we multiply by the scalar to see the direction of the ray

         if (Physics.Raycast(ray, out hit))
         {
                    Debug.DrawRay(ray.origin, ray.direction * raygizmo, Color.green); //we multiply by the scalar to see the direction of the ray

         }
        */
        dist = Vector3.Distance(player.position, transform.position);

        if(dist<=detect_player && Time.time >= nextFire)
        {

            turrethead.LookAt(player);
            turrethead.transform.Rotate(-91f, turrethead.transform.rotation.y, turrethead.transform.rotation.z);


            nextFire = Time.time + 1f / fireRate;
                Shoot();
            
        }

    }
    void Shoot()
    {

        GameObject bulletclone = Instantiate(projectile,spawnpoint.position,spawnpoint.rotation); // this just instantiate the bullet 
        bulletclone.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * 1500); //this actually applies the force in the rigidbody
        Destroy(bulletclone, 3f);
    }
}
