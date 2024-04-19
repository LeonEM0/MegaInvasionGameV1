using UnityEngine;

public class Enemy : MonoBehaviour,IDamageable
{
    private int health = 50;
    public int damage = 10;
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
        //Instantiate(impact_explosion, this.transform.position, this.transform.rotation);

        if (health <= 0)
        {
            AudioManagerSingleton.Instance.PlaySound(deathsound);
            GameObject particle1 = Instantiate(death_explosion, this.transform.position, this.transform.rotation); // you need to save the instatiation in variable of typeGamobject to then destroy it 
            GameObject particle2 = Instantiate(impact_explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject); // Destroy the enemy if health drops to or below 0
            Debug.Log("EnemKilled");
            // Destroy(impact_explosion, 1f);
            //Destroy(death_explosion, 1f);
            Destroy(particle1, 1);
            Destroy(particle2, 1);

        }
    }
}