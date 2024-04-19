using UnityEngine;

public class InstantDeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDamage playerDamage = other.GetComponent<PlayerDamage>();
            if (playerDamage != null)
            {
                playerDamage.TakeDamage(100);
            }
        }
    }
}
