using System.IO;
using UnityEngine;
using SimpleJSON;
using Directory = UnityEngine.Windows.Directory;
using File = System.IO.File;

public class Util
{

    public static int score;

    #region fileIO

    public static Vector3 GetVector3FromFile(string dir, string fileName)
    {
        string fileContents = ReadStringFromFile(dir, fileName);

        if (fileContents == null)
        {
            Debug.Log("No content in file");
            return new Vector3();
        }

        return JsonUtility.FromJson<Vector3>(fileContents);
    }
    
    public static string ReadStringFromFile(string dir, string fileName)
    {
        #if UNITY_EDITOR
            dir = Application.dataPath + dir;
        #else
            dir = Application.persistentDataPath + dir;     
        #endif

        if (File.Exists(dir + fileName))
        {
            return File.ReadAllText(dir + fileName);
        }
        else
        {
            Debug.Log("File Not Found: " + dir + fileName);
            return null;
        }
    }

    public static void SaveVec3ToFileAsJson(string dir, string fileName, Vector3 vec)
    {
        //File.WriteAllText(fileName, JsonUtility.ToJson(vec));
        SaveStringToFile(dir, fileName, JsonUtility.ToJson(vec));
    }

    public static void SaveStringToFile(string dir, string fileName, string fileContent)
    {
        #if UNITY_EDITOR
            dir = Application.dataPath + dir;
        #else
            dir = Application.persistentDataPath + dir;
        #endif

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        fileName = dir + fileName;

        File.WriteAllText(fileName, fileContent);
    }

    #endregion

}
