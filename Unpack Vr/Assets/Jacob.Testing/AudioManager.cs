using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioDetails[] musicAudio, sfxAudio;
    public AudioSource musicSource, sfxSource;

    [SerializeField] private Slider musicSlider, sfxSlider; //masterSlider;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BackgroundMusic(Test)");
        MusicVolume(musicSlider.value);
        SFXVolume(sfxSlider.value);
    }

    public void PlayMusic(string name)
    {
        AudioDetails audio = Array.Find(musicAudio, x => x.audioName== name);
        if(audio == null) { Debug.Log("Audio not found"); }
        else
        {
            musicSource.clip = audio.clip;
            musicSource.Play();
        }

    }

    public void PlaySFX(string name)
    {
        AudioDetails audio = Array.Find(sfxAudio, x => x.audioName == name);
        if (audio == null) { Debug.Log("Audio not found"); }
        else
        {
            sfxSource.clip = audio.clip;
            sfxSource.PlayOneShot(audio.clip);
        }

    }


    public void ToggleMusic() { musicSource.mute = !musicSource.mute; }
    public void ToggleSFX() { sfxSource.mute = !sfxSource.mute; }
    public void MusicVolume(float volume) { volume = musicSlider.value; musicSource.volume = volume; }
    public void SFXVolume(float volume) { volume = sfxSlider.value;  sfxSource.volume = volume; }
    //public void MasterVolume(float value) { AudioListener.volume = value; }


}
