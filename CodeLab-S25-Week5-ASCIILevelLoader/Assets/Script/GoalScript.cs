using System;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
 void OnCollisionEnter(Collision other)
 {
   GameObject gameManager = GameObject.Find("GameManager");
   gameManager.GetComponent<ASCIILevelLoader>().CurrentLevel++;
 }
}
