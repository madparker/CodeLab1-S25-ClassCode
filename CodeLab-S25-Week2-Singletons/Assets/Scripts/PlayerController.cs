using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode keyUp    = KeyCode.W;
    public KeyCode keyDown  = KeyCode.S;
    public KeyCode keyLeft  = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;

    Rigidbody rb;

    public float moveForce = 1f;

    public static PlayerController instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity *= 0.99f;
        
        if (Input.GetKey(keyUp))
        {
            rb.AddForce(Vector3.up * moveForce);
        }

        if (Input.GetKey(keyDown))
        {
            rb.AddForce(Vector3.down * moveForce);
        }

        if (Input.GetKey(keyLeft))
        {
            rb.AddForce(Vector3.left * moveForce);
        }

        if (Input.GetKey(keyRight))
        {
            rb.AddForce(Vector3.right * moveForce);
        }
    }
}
