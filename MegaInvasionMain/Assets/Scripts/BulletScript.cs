using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float timeToDestroy = 5;
    [SerializeField] private float damage = 25;
    

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

        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
       // transform.forward will always shoot in the +z axis 
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
       
       
       
    }
    */
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>(); // were storing an interface in the damageable variable when is colliding with the other object
        
        if(damageable != null)   // if the object  clashed with an object that contains the interface the variable will store the interface
        {
            damageable.TakeDamage(25); // if the damafeable variable is not null, it calls the takeDamage method on the damageable object 
            //we will use this variable and this method to call takedamage and affect the objects that were hit
            DestroyProjectile();
        }

      /*  else if(other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Plane"))
        {
            DestroyProjectile();
        }
      */
    }

   public void DestroyProjectile()
    {
        Destroy(this.gameObject);
    }
   

}
