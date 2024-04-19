using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;
    public float volumeIncrement = 0.1f;
    public float initialVolume = 50f;

    void Start()
    {
        
            audioSource.volume = initialVolume; // Normalize to 0-1 range
     
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            IncreaseVolume();
        }
    }

    void IncreaseVolume()
    {
        if (audioSource != null)
        {
            audioSource.volume += volumeIncrement;
            Debug.Log("Volume increased to: " + audioSource.volume);
        }
        else
        {
            Debug.LogWarning("AudioSource component not found!");
        }
    }
}
