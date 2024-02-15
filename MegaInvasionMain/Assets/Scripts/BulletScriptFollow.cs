using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletScriptFollow : MonoBehaviour
{
    private NavMeshAgent enemy;
    public Transform player;
    // Start is called before the first frame update
    public GameObject enemyBullet;
    public Transform spawnPoint;
    [SerializeField] private float timer = 5;
    private float bulletTime;
    public float enemyspeed;
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;
        bulletTime = timer;

        GameObject bulletObj = Instantiate(enemyBullet, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemyspeed);

        if(bulletObj.transform.position == player.transform.position)
        {
            bulletObj.SetActive(false);
        }

        
     }
 


}
