using UnityEngine;

public class UtilScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 CloneVec3(Vector3 vec)
    {
        return new Vector3(vec.x, vec.y, vec.z);
    }
}
