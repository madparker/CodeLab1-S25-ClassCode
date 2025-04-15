using UnityEngine;

public class InvincibleShield : BaseShield
{
    float shieldDuration = 10f;

    public SpriteRenderer sRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Collider2D>().enabled = false;
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.color = new Color(0, 144f/255f, 5/255f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        shieldDuration -= Time.deltaTime;

        if (shieldDuration <= 0)
        {
            sRenderer.color = new Color(0, 144f/255f, 5/255f, 1f);
            gameObject.GetComponent<Collider2D>().enabled = true;
            Destroy(this);
        }
    }
}
