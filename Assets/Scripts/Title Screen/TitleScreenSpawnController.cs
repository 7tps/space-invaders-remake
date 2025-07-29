using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenSpawnController : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public Sprite[] enemySprites;
    
    [Header("Spawn Position Settings")]
    public float spawnXRange = 8f;
    public float spawnYPosition = 3f;

    [Header("Spawn Rate Settings")]
    public float spawnStart = 1f;
    public float spawnDelay = 2f;
    
    
    // Start is called before the first frame update
    void Start()
    {
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
        
        Vector3 enemyPos = new Vector3(Random.Range(-spawnXRange, spawnXRange), spawnYPosition, 0);
        Sprite s = enemySprites[(int) Random.Range(0, enemySprites.Length)];
        
        GameObject enemy = Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
        enemy.GetComponent<SpriteRenderer>().sprite = s;
        
    }

   

}
