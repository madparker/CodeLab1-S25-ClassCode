using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public ShipControl shipControl;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Destroy(shipControl.shield);
            // destroy the old shield
            gameObject.AddComponent<BaseShield>();
            // add a new shield
        }
    }
}
