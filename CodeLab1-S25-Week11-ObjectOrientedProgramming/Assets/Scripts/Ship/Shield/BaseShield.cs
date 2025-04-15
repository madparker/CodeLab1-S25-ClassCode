using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShield : MonoBehaviour
{
    public float shieldStrength = 50; 
    // The strength of the shield

    public virtual float AdjustDamage(float damage){
        //calculating the damage taken by the ship based on the shield strength
        if(shieldStrength > damage)
        {
            shieldStrength -= damage;
            return 0;  
            // not doing damage to the ship, we have shields left
        } else if(shieldStrength > 0){
            damage = damage - shieldStrength;
            shieldStrength = 0;
            // damage exceeds rest of the shield strength
            // shields are gone, we deal the rest of the damage to the ship
            return damage;
        } else { 
            // no shields, direct damage to the ship
            return damage;
        }
    }
}
