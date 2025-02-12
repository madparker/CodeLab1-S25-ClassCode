using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WhackADot : MonoBehaviour
{
    public float range = 5;
    
    void OnMouseDown()
    {
        //TODO Make this function do something for reals
        //throw new NotImplementedException();

        GameManager.instance.Score++;
        
        transform.position = new Vector2(
            Random.Range(-range, range),
            Random.Range(-range, range));
    }
}
