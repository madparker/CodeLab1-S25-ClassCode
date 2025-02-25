using System;
using UnityEngine;

public class WASDPlayerControl : MonoBehaviour
{
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyLeft;
    public KeyCode keyRight;
    
    public float speed = 1;
    
    Rigidbody rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyUp))
        {
            rb.AddForce(Vector3.up * speed);
        }
        
        if(Input.GetKey(keyDown))
        {
            rb.AddForce(Vector3.down * speed);
        }
        
        if(Input.GetKey(keyLeft))
        {
            rb.AddForce(Vector3.left * speed);
        }
        
        if(Input.GetKey(keyRight))
        {
            rb.AddForce(Vector3.right * speed);
        }
    }
}
