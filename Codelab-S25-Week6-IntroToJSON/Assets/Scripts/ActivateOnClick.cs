using System;
using UnityEngine;

public class ActivateOnClick : MonoBehaviour
{
    Rigidbody rb;
    
    #region Unity Event Functions
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        rb.useGravity = true;
    }
    
    #endregion
    
    #region NonEvent Functions
    
    #endregion
}
