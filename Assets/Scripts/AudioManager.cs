using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;

    public float volume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;

    public MusicController music;
    public SFXManager sfx;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void updateVolume(float value)
    {
        volume = value;
        music.updateVolume();
        sfx.updateVolume();
    }

    public float getMusicVolume()
    {
        return musicVolume * volume;
    }

    public float getSFXVolume()
    {
        return sfxVolume *  volume;
    }
}
