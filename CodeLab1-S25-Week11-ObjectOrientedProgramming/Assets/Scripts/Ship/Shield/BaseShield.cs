using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShield : MonoBehaviour
{
    public float shieldStrength = 50; 

    public virtual float AdjustDamage(float damage){
        if(shieldStrength > damage)
        {
            shieldStrength -= damage;
            return 0;  
        } else if(shieldStrength > 0){
            damage = damage - shieldStrength;
            shieldStrength = 0;
            return damage;
        } else { 
            return damage;
        }
    }
}
