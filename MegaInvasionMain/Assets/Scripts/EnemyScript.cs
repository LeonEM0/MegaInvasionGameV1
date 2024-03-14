using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    BulletScript bulletScript;
    private void Start()
    {
        bulletScript = GetComponent<BulletScript>();
    }
 

    private void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the enemy if health drops to or below 0
        }
    }
}