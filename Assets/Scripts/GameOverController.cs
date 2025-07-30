using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public string mainGameScene; 
    public string titleScreenScene; 
    
    public void RestartGame()
    {
        Debug.Log("Restarting game...");
        SceneManager.LoadScene(mainGameScene);
    }
    
    public void ReturnToTitle()
    {
        Debug.Log("Returning to title screen...");
        SceneManager.LoadScene(titleScreenScene);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
} 