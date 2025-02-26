using System;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
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
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<ASCIILevelLoader>().LoadLevel();
    }
}
