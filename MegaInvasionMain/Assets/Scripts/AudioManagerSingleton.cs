using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerSingleton : MonoBehaviour
{
   [SerializeField] private AudioSource sfxAudioSource, musicAudioSource;

    public static AudioManagerSingleton Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }









}
