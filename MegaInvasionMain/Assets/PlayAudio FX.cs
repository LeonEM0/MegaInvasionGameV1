using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAudioFX : MonoBehaviour
{
    public AudioSource soundPlayer;



    // Start is called before the first frame update
    void Start()
    {
        soundPlayer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySFX()
    {
        if (soundPlayer.enabled)
        {
            soundPlayer.Play();
        }
        else
        {
            Debug.LogWarning("Canot play audio: AudioSource component disabled");
        }
    }
}
