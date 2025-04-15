using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bullet; 
    void Start()
    {
        InvokeRepeating("Fire", 1, 1);
    }

    void Fire(){
        Instantiate<GameObject>(bullet);
    }
}
