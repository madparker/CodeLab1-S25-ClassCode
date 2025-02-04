using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrizeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        GameManager.instance.Score++;

        transform.position = new Vector3(
            Random.Range(-5, 5),
            Random.Range(-5, 5), 0);
    }
}
