using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isDead;

    public HealthBar healthBar;
    public GameOverScreen deathScreen;
    public AudioClip playerdamagedsound;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            deathScreen.gameOver();
            Destroy(this);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        AudioManagerSingleton.Instance.PlaySound(playerdamagedsound);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            TakeDamage(20);
        }
        if (other.tag == "Bullet")
        {
            TakeDamage(5);
        }
    }
}
