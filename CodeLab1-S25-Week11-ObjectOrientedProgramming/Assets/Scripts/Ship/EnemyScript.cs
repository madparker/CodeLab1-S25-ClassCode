using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject bullet; 
    //reference to the bullet
    void Start()
    {
        InvokeRepeating("Fire", 1, 1);
        //repeating the fire function every second
    }

    void Fire(){
        Instantiate<GameObject>(bullet);
        //  instantiating the bullet prefab at the current position of the enemy
    }
}
