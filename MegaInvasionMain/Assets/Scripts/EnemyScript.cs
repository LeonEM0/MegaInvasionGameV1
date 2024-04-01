using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    private int health = 50;
    BulletScript bulletScript;
    [SerializeField] AudioClip deathsound;
    private void Start()
    {
        bulletScript = GetComponent<BulletScript>();
    }
 

    public void  TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log(health);

        if (health <= 0)
        {
            AudioManagerSingleton.Instance.PlaySound(deathsound);
            Destroy(gameObject); // Destroy the enemy if health drops to or below 0
            Debug.Log("EnemKilled");
        }
    }
}