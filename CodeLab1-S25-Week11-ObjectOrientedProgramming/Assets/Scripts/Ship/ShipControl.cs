using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    //left and right controller
    public KeyCode leftKey;
    public KeyCode rightKey;

    //speed of ship
    public float forceMod = 10;

    Rigidbody2D rb2d;

    //health of ship
    public float health = 100;
    
    //ship health text
    public TextMesh healthText;

    //create the objects/instances of BaseAttack and BaseShield classes
    public BaseAttack attack;
    public BaseShield shield;

    void Start()
    {
        //get ship rb
        rb2d = GetComponent<Rigidbody2D>();
        
        //get baseshielf component from inspector
        shield = GetComponent<BaseShield>();
    }

    void Update()
    {
        //when you hit space, creates an object of BaseAttack class, which spawns a bullet prefab
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = GetComponent<BaseAttack>();
            //if base attack exists
            //spawns a bullet in front of the ship, which moves upwards

            if (attack != null)
            {
                //call the Attack function from baseattack
                attack.Attack();
            }
        }

        //move left
        if(Input.GetKey(leftKey)){ 
            rb2d.AddForce(Vector2.left * forceMod);
        }
    
        //move right
        if (Input.GetKey(rightKey)){ 
            rb2d.AddForce(Vector2.right * forceMod);
        }
    }

    //when ship is hit by bullet, take 20 damage to health and destroy bullet
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        TakeDamage(20);
    }

    
    public void TakeDamage(float damageAmt)
    {
        //creating object of class shield

        shield = GetComponent<BaseShield>();
        
        //if shield exists
        if (shield != null)
        {
            //run the AdjustDamage function from the baseshield class
            damageAmt = shield.AdjustDamage(damageAmt);

        }
        
        //health takes the modified damage after shield calculation
        health -= damageAmt;
        //prints the new health
        healthText.text = "Health: " + health;

        //if shield exists
        if (shield != null)
        {
            //print the new shield text
            healthText.text += "\nShield: " + shield.ToString();
        }
    }
}
