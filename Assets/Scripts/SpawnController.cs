using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public GameObject[] enemyPrefabs;

    [Header("Spawn Position Settings")]
    public float spawnXRange = 8f;
    public float spawnYPosition = 3f;

    [Header("Spawn Rate Settings")]
    public float spawnStart = 2f;
    public float spawnDelay = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnStart, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        GameObject enemy = enemyPrefabs[(int) Random.Range(0, enemyPrefabs.Length)];
        Vector3 enemyPos = new Vector3(Random.Range(-spawnXRange, spawnXRange), spawnYPosition, 0);
        
        Instantiate(enemy, enemyPos, Quaternion.identity);
    }
}
