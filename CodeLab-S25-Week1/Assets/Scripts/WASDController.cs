using UnityEngine;

public class WASDController : MonoBehaviour
{
    public KeyCode keyUp = KeyCode.W;

    public Rigidbody rb;

    public float moveForce = 10f;

    Vector3 testVec;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("START!!!");

        rb = null;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update...");

        if (Input.GetKey(keyUp))
        {
            rb.AddForce(testVec * moveForce);
        }
    }
}
