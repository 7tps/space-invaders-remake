using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    
    public GameObject[] lives;
    public int livesRemaining = 3;
    public string gameOverScene = "Game Over Screen";
    
    public static LifeManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void loseLife()
    {
        livesRemaining--;
        if (livesRemaining <= 0)
        {
            StartCoroutine(PlayLastLifeAnimationAndGameOver());
        }
        else
        {
            Animator animator = lives[livesRemaining].GetComponent<Animator>();
            animator.Play("lose_life");
        }
    }

    private IEnumerator PlayLastLifeAnimationAndGameOver()
    {
        Animator animator = lives[0].GetComponent<Animator>(); 
        animator.Play("lose_life");
        
        AnimationClip clip = animator.runtimeAnimatorController.animationClips[0];
        float animationLength = clip.length;
        
        yield return new WaitForSeconds(animationLength);
        
        SceneManager.LoadScene(gameOverScene);
    }
}