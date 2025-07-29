using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    
    public AudioSource source;
    
    public static MusicController instance;

    public float volume = 1f;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void updateVolume()
    {
        source.volume = volume * AudioManager.instance.volume;
    }
}
