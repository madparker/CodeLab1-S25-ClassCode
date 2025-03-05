using System.IO;
using UnityEngine;
using SimpleJSON;
using Directory = UnityEngine.Windows.Directory;
using File = System.IO.File;

public class Util
{

    public static int score;

    //region for all the fileIO
    #region fileIO

    //Get a vec3 from a file
    public static Vector3 GetVector3FromFile(string dir, string fileName)
    {
        //Use ReadStringFromFile below to get file contents as string
        string fileContents = ReadStringFromFile(dir, fileName);

        //if there are no fileContents 
        if (fileContents == null)
        {
            Debug.Log("No content in file");
            return new Vector3(); //send empty Vec3 
        }

        //convert json to Vec3 and return it
        return JsonUtility.FromJson<Vector3>(fileContents);
    }
    
    //Get string from file
    public static string ReadStringFromFile(string dir, string fileName)
    {
        //if we are in the Unity editor
        #if UNITY_EDITOR
            //use dataPath
            dir = Application.dataPath + dir;
        #else //otherwise
            //use persistentDataPath
            dir = Application.persistentDataPath + dir;     
        #endif

        //if the file exists
        if (File.Exists(dir + fileName))
        {
            //return the text
            return File.ReadAllText(dir + fileName);
        }
        else
        {
            Debug.Log("File Not Found: " + dir + fileName);
            return null;
        }
    }

    //convert Vec3 to JSon and save the string
    public static void SaveVec3ToFileAsJson(string dir, string fileName, Vector3 vec)
    {
        //File.WriteAllText(fileName, JsonUtility.ToJson(vec));
        SaveStringToFile(dir, fileName, JsonUtility.ToJson(vec));
    }

    //save string to file
    public static void SaveStringToFile(string dir, string fileName, string fileContent)
    {
        //if we are in the Unity editor
        #if UNITY_EDITOR
            //use dataPath
            dir = Application.dataPath + dir;
        #else//otherwise
            //use persistentDataPath
            dir = Application.persistentDataPath + dir;
        #endif

        //if there's no dir
        if (!Directory.Exists(dir))
        {
            //make the dir
            Directory.CreateDirectory(dir);
        }

        fileName = dir + fileName;
        
        File.WriteAllText(fileName, fileContent);
    }

    #endregion

}
