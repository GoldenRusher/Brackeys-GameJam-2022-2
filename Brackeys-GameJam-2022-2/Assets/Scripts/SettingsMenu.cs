using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer Main;

    public float SFXVol;
    public float MusicVol;
    public float MasterVol;
    public bool fullScreen = true;

    public Slider SFX;
    public Slider Music;
    public Slider Master;
    public Toggle fsToggle;

    private void Start()
    {
        SFXVol = PlayerPrefs.GetFloat("SFXVolume");
        MusicVol = PlayerPrefs.GetFloat("MusicVolume");
        MasterVol = PlayerPrefs.GetFloat("MasterVolume");
        if (PlayerPrefs.GetInt("FullScreen") == 1) 
        {
            fullScreen = true;
        }
        else 
        {
            fullScreen = false;
        }

        SFX.value = SFXVol;
        Music.value = MusicVol;
        Master.value = MasterVol;
        fsToggle.isOn = fullScreen;

        Main.SetFloat("SFXvol", SFXVol);
        Main.SetFloat("MusicVol", MusicVol);
        Main.SetFloat("MasterVol", MasterVol);
        Screen.fullScreen = fullScreen;
    }

    public void SetSFXVolume(float volume) 
    {
        Main.SetFloat("SFXvol", volume);
        SFXVol = volume;
    }
    public void SetMusicVolume(float volume)
    {
        Main.SetFloat("MusicVol", volume);
        MusicVol = volume;
    }
    public void SetMainVolume(float volume)
    {
       Main.SetFloat("MasterVol", volume);
       MasterVol = volume;
    }

    public void FullScreen(bool FS) 
    {
        Screen.fullScreen = FS;
        fullScreen = FS;
    }


    public void Save() 
    {
        PlayerPrefs.SetFloat("SFXVolume", SFXVol);
        PlayerPrefs.SetFloat("MusicVolume", MusicVol);
        PlayerPrefs.SetFloat("MasterVolume", MasterVol);
        if (fullScreen) 
        {
            PlayerPrefs.SetInt("FullScreen",1);
        }
        else 
        {
            PlayerPrefs.SetInt("FullScreen", 0);
        }
        
    }
}
