using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    
    public AudioSource source;

    void Start()
    {
        updateVolume();
    }
    
    public void updateVolume()
    {
        source.volume = AudioManager.instance.musicVolume * AudioManager.instance.volume;
    }
}
