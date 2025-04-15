using System;
using UnityEngine;

public class AbsorbShield : BaseShield
{
    float shieldDuration = 10f;
    
    public override float AdjustDamage(float damage)
    {
        if (shieldDuration > 0)
        {
            return -damage;
        }
        else
        {
            return damage;
        }
    }

    void Update()
    {
        shieldDuration -= Time.deltaTime;  //0.0167f
    }
}
