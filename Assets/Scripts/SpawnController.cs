using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{

    public GameObject enemyPrefab;
    public Sprite[] enemySprites;

    public UIController ui;
    
    [Header("Spawn Position Settings")]
    public float spawnXRange = 8f;
    public float spawnYPosition = 3f;

    [Header("Spawn Rate Settings")]
    public float spawnStart = 2f;
    public float spawnDelay = 3f;
    
    [Header("Difficulty Buttons")]
    public Button easyButton;
    public Button hardButton;

    [Header("Button Colors")] 
    public ColorBlock active;
    public ColorBlock inactive;
    
    // Start is called before the first frame update
    void Start()
    {
        active = easyButton.colors;
        active.normalColor = new Color32(160, 160, 160, 255);
        active.highlightedColor = new Color32(100, 100, 100, 255);
        easyButton.colors = active;
        
        inactive = hardButton.colors;
        inactive.normalColor = Color.white;
        inactive.highlightedColor = new Color32(180, 180, 180, 255);
        hardButton.colors = inactive;
        
        StartCoroutine(SpawnEnemyCoroutine());
    }

    private IEnumerator SpawnEnemyCoroutine()
    {
        yield return new WaitForSeconds(spawnStart);
    
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnEnemy()
    {
        
        if (UIController.instance.pauseActive)
        {
            return;
        }
        
        Vector3 enemyPos = new Vector3(Random.Range(-spawnXRange, spawnXRange), spawnYPosition, 0);
        Sprite s = enemySprites[(int) Random.Range(0, enemySprites.Length)];
        
        GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
        enemy.GetComponent<SpriteRenderer>().sprite = s;
        
    }

    public void setDifficulty(string difficulty)
    {
        Debug.Log("Setting difficulty: " + difficulty + ".");
        if (difficulty == "easy")
        {
            spawnDelay = 3f;
            easyButton.colors = active;
            hardButton.colors = inactive;
        }

        if (difficulty == "hard")
        {
            spawnDelay =  0.75f;
            easyButton.colors = inactive;
            hardButton.colors = active;
        }
        
        EventSystem.current.SetSelectedGameObject(null);
    }
}
