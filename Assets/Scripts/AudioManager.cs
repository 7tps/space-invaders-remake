using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    
    public AudioClip shootSFX;
    public AudioClip destroySFX;

    public static AudioManager instance;
    
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
}
