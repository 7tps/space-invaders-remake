using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenMoveForward : MonoBehaviour
{

    public bool enemy = false;
    
    public float moveSpeed;

    public float upperBound = 7f; 
    public float lowerBound = -7f; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (enemy)
        {
            moveSpeed = Random.Range(-1, -5);
        }
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
}