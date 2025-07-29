using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 10f;
    public float xBound;

    public GameObject laser;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, 0);
        }
        if (transform.position.x < -1 * xBound)
        {
            transform.position = new Vector3((-1 * xBound), transform.position.y, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
        
    }
}
