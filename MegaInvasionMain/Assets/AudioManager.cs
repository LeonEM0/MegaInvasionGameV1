using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource backgroundMusicAudioSource;
    public AudioSource soundFXAudioSource;

    public Slider MasterVolumeSlider;
    public Slider SoundEffectsVolumeSlider;
    public Toggle MuteToggle;

    private float MasterVolume = 1f;
    private float SoundEffectsVolume = 1f;
    private bool isMuted = false;

    //To Ensure only one AudioManager Exists (Awake is before Start)
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        MasterVolumeSlider.value = MasterVolume;
        SoundEffectsVolumeSlider.value = SoundEffectsVolume;
        MuteToggle.isOn = isMuted;

        SetMasterVolume(MasterVolume);
        SetSoundEffectsVolume(SoundEffectsVolume);
        ToggleMute(isMuted);
    }

    public void SetMasterVolume(float volume)
    {
        MasterVolume = volume;
        backgroundMusicAudioSource.volume = MasterVolume;
    }

    public void SetSoundEffectsVolume(float volume)
    {
        SoundEffectsVolume = volume;
        soundFXAudioSource.volume = SoundEffectsVolume;
    }
    public void ToggleMute(bool isMuted)
    {
        this.isMuted = isMuted;
        backgroundMusicAudioSource.volume = isMuted ? 0f : MasterVolume;
    }
}

