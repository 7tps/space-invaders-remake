using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    
    public static UIController instance;
    
    public bool pauseActive = false;
    
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;
    
    public MusicController music;
    public SFXManager sfx;

    public string titleScene;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                pauseActive = false;
            }
            else
            {
                if (!settingsMenu.activeSelf)
                {
                    pauseMenu.SetActive(true);
                    pauseActive = true;
                }
            }
        }
    }
    
    public void updateMasterVolume(float value)
    {
        value = masterSlider.value;
        AudioManager.instance.updateVolume(value);
    }
    
    public void updateMusicVolume(float value)
    {
        value = musicSlider.value;
        AudioManager.instance.musicVolume = value;
        music.updateVolume();
    }
    
    public void updateSFXVolume(float value)
    {
        value = SFXSlider.value;
        AudioManager.instance.sfxVolume = value;
        sfx.updateVolume();
    }
    
    public void showSettings()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        pauseActive = true;
    }

    public void returnToPause()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
        pauseActive = true;
    }

    public void returnToGame()
    {
        pauseMenu.SetActive(false);
        pauseActive = false;
    }

    public void returnToTitle()
    {
        pauseMenu.SetActive(false);
        pauseActive = false;
        SceneManager.LoadScene(titleScene);
    }
}
