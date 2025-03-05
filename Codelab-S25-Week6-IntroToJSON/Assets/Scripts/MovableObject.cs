using System;
using System.IO;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    string dir = "/Data/";
    string fileName;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        fileName = name + ".json";
        
        //use static function in Util to get the vec from the file
        transform.position = Util.GetVector3FromFile(dir, fileName);

        // string dataPath = Application.dataPath + "/Data/";
        //
        // if (!Directory.Exists(dataPath))
        // {
        //     Directory.CreateDirectory(dataPath);
        // }
        //
        // fileName = dataPath + name + ".json";
        //
        // if (File.Exists(fileName))
        // {
        //     string fileContent = File.ReadAllText(fileName);
        //
        //     transform.position = JsonUtility.FromJson<Vector3>(fileContent);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        //get the world postion of the mouse
        Vector3 mousePosition = GetMouseWorldPosition();
        
        Debug.Log(mousePosition);

        //set the position of the object to the mouses world position
        transform.position = mousePosition;
    }

    Vector3 GetMouseWorldPosition()
    {
        //Get the X and Y of the mouse on the screen
        Vector3 mousePosition = Input.mousePosition;

        //considering where this gameObject is in worldspace
        //get the z position in screen space
        mousePosition.z =
            Camera.main.WorldToScreenPoint(transform.position).z;
        
        Debug.Log("Z in Screen Pixels:" + mousePosition.z);

        //convert the mouse position to a world point
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        
        Debug.Log(("Z in World Units: " + mousePosition.z));

        return mousePosition;
    }

    void OnApplicationQuit()
    {
        // string jsonPos = JsonUtility.ToJson(transform.position, true);
        //
        // File.WriteAllText(fileName, jsonPos);
        
        //use Util function to save the vec3 to a Json file
        Util.SaveVec3ToFileAsJson(dir, fileName, transform.position);
    }
}
