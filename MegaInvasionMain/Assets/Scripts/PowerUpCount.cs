using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    private void Start()
    {
        UpdateCount();  
    }

    void OnEnable()
    {
        PowerUps.OnCollected += OnPowerUpCollected;
    }

    void OnDisable()
    {
        PowerUps.OnCollected -= OnPowerUpCollected;    
    }

    void OnPowerUpCollected()
    {
        count++;
        UpdateCount();
    }

    void UpdateCount()
    {
        text.text = $"{count} /{ PowerUps.total}";
    }
}
