using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private bool isDead;

    public HealthBar healthBar;
    public GameOverScreen deathScreen;

   


    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            deathScreen.gameOver();
        }  
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            TakeDamage(20);
        }
        if(other.tag == "Bullet")
        {
            TakeDamage(5);
        }
    }
}
