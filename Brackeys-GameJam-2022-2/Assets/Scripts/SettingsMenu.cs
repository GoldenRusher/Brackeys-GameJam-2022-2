using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using FMOD;

public class SettingsMenu : MonoBehaviour
{

    public float SFXVol;
    public float MusicVol;
    public float MasterVol;
    public float ShakeInt;
    public bool fullScreen = true;

    public Slider Shake;
    public Slider SFX;
    public Slider Music;
    public Slider Master;
    public Toggle fsToggle;

    FMOD.Studio.Bus masterBus;
    FMOD.Studio.Bus SFXBus;
    FMOD.Studio.Bus MusicBus;

    private void Start()
    {
        //SFXBus = FMODUnity.RuntimeManager.GetBus("bus:/SoundFX");
        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/Master");
        MusicBus = FMODUnity.RuntimeManager.GetBus("bus:/Music");

        SFXVol = PlayerPrefs.GetFloat("SFXVolume");
        MusicVol = PlayerPrefs.GetFloat("MusicVolume");
        MasterVol = PlayerPrefs.GetFloat("MasterVolume");
        ShakeInt = PlayerPrefs.GetFloat("ShakeIntensity");
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
        Shake.value = ShakeInt;
        fsToggle.isOn = fullScreen;

        SFXBus.setVolume(SFXVol);
        MusicBus.setVolume(MusicVol);
        masterBus.setVolume(MasterVol);

        Screen.fullScreen = fullScreen;
    }

    public void SetSFXVolume(float volume) 
    {
        SFXBus.setVolume(volume);
        SFXVol = volume;
    }
    public void SetMusicVolume(float volume)
    {
        MusicBus.setVolume(volume);
        MusicVol = volume;
    }
    public void SetMainVolume(float volume)
    {
        masterBus.setVolume(volume);
        MasterVol = volume;
    }
    public void SetShakeInt(float Int) 
    {
        PlayerPrefs.SetFloat("ShakeIntensity", Int);
        ShakeInt = Int;
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
