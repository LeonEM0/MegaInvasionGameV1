using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    private int health = 50;
    BulletScript bulletScript;
    [SerializeField] AudioClip deathsound;
    [SerializeField] AudioClip bulletimpactsound;
    [SerializeField] GameObject impact_explosion;
    [SerializeField] GameObject death_explosion;
    private void Start()
    {
        bulletScript = GetComponent<BulletScript>();
    }
 

    public void  TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log(health);
        AudioManagerSingleton.Instance.PlaySound(bulletimpactsound);
        Instantiate(impact_explosion, this.transform.position, this.transform.rotation);

        if (health <= 0)
        {
            AudioManagerSingleton.Instance.PlaySound(deathsound);
           
            Instantiate(death_explosion, this.transform.position, this.transform.rotation);
            Destroy(gameObject); // Destroy the enemy if health drops to or below 0
            Debug.Log("EnemKilled");

        }
    }
}