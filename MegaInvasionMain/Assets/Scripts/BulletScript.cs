using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float timeToDestroy;
    [SerializeField] private float damage = 10;
    

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyProjectile), timeToDestroy);
        //Invoke() method: This method allows you to call a method after a specified delay.
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(transform.forward * (speed * Time.deltaTime));
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
       
       
       
    }
    */
    private void OnTriggerEnter(Collider collider)
    {
        Enemy enemy = collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(25);
            Debug.Log(enemy.health);
        }
    }

   public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
   

}
