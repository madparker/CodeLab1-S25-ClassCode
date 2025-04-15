using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{

    public GameObject bulletPrefab;
    //reference to the bullet prefab
    public virtual void Attack()
    {
        Vector2 currentPos = transform.position;
        //getting the current position of the ship
        currentPos.y += 1;
        //shooting the bullet from the ship
        SpawnBullet(currentPos);
    }

    public virtual void SpawnBullet(Vector2 pos)
    {
        GameObject bullet = Instantiate<GameObject>(bulletPrefab);

        bullet.GetComponent<Rigidbody2D>().gravityScale = -1;
        //bullet goes up
        bullet.transform.position = pos;
        //instantiating the bullet prefab at the current position of the ship
    }

}
