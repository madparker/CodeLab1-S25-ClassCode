using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public KeyCode leftKey;
    public KeyCode rightKey;

    public float forceMod = 10;

    Rigidbody2D rb2d;

    public float health = 100;
    public TextMesh healthText;

    public BaseAttack attack;
    public BaseShield shield;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shield = GetComponent<BaseShield>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = GetComponent<BaseAttack>();

            if (attack != null)
            {
                attack.Attack();
            }
        }

        if(Input.GetKey(leftKey)){ 
            rb2d.AddForce(Vector2.left * forceMod);
        }

        if (Input.GetKey(rightKey)){ 
            rb2d.AddForce(Vector2.right * forceMod);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        TakeDamage(20);
    }

    public void TakeDamage(float damageAmt)
    {

        shield = GetComponent<BaseShield>();
        
        if (shield != null)
        {
            damageAmt = shield.AdjustDamage(damageAmt);

        }

        health -= damageAmt;
        healthText.text = "Health: " + health;

        if (shield != null)
        {
            healthText.text += "\nShield: " + shield.ToString();
        }
    }
}
