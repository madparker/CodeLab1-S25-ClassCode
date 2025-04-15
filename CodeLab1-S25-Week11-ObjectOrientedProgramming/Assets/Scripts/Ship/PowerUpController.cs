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
        } else if (Input.GetKeyDown(KeyCode.H))
        {
            Destroy(shipControl.shield);
            gameObject.AddComponent<HalfDamageShield>();
        } else if (Input.GetKeyDown(KeyCode.I))
        {
            Destroy(shipControl.shield);
            gameObject.AddComponent<InvincibleShield>();
        }
    }
}
