using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource source;
    
    public AudioClip shootSFX;
    public AudioClip destroySFX;

    public static SFXManager instance;

    public float volume = 1f;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void playSFX(string sfx)
    {
        if (sfx == "shoot")
        {
            source.PlayOneShot(shootSFX);
        }
        if (sfx == "destroy")
        {
            source.PlayOneShot(destroySFX);
        }
    }

    public void updateVolume()
    {
        source.volume = volume * AudioManager.instance.volume;
    }
}
