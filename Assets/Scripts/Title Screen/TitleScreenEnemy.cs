using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenEnemy : MonoBehaviour
{
    
    public float moveSpeed;

    public float upperBound = 7f; 
    public float lowerBound = -7f;

    public GameObject enemyLaserPrefab;
    
    [Header("Audio")]
    public AudioClip shootSound;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(-3, -5);
        
        StartCoroutine(SpawnLasers());
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(moveSpeed * Time.deltaTime * Vector2.up);
    
        if (transform.position.y > upperBound)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < lowerBound)
        {
            Destroy(gameObject);
        }
            
    }
    
    private IEnumerator SpawnLasers()
    {
        while (true)
        {
            
            if (transform.position.y < -5)
            {
                break;
            }
            
            float waitTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(waitTime);
            
            if (enemyLaserPrefab != null)
            {
                Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}