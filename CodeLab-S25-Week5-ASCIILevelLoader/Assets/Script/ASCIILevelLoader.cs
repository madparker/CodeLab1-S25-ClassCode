using System;
using System.IO;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    public GameObject prefabPlayer;
    public GameObject prefabWall;
    
    string filePath;

    public string fileName;

    public int currentLevel = 0;
    
    public float offsetX = -3;
    public float offsetY = -3;

    GameObject levelHolder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        if (levelHolder != null)
        {
            Destroy(levelHolder);
        }

        levelHolder = new GameObject("levelHolder");

        filePath = Application.dataPath;

        //string fileContents = File.ReadAllText(filePath + fileName);
        //Debug.Log(fileContents);

        string[] lines = File.ReadAllLines(filePath + fileName);

        //looping through each line of the file
        for (int y = 0; y < lines.Length; y++)
        {
            Debug.Log(lines[y]);

            string line      = lines[y]; //getting the string for this line
            char[] charArray = line.ToCharArray();//turn that string into a char array
            
            //loop through each character on this line
            for (int x = 0; x < charArray.Length; x++)
            {
                char c = charArray[x];

                GameObject newObj = null; //create a holder for a new prefab instance

                switch (c)
                {
                    case 'P': //we got a P in the file
                        newObj = Instantiate<GameObject>(prefabPlayer);
                        break;
                    case 'W': //we got a W in the file
                        newObj = Instantiate<GameObject>(prefabWall);
                        break;
                    default:
                        break;
                }

                if (newObj != null)
                {
                    newObj.transform.parent = levelHolder.transform;
                    newObj.transform.position =
                        new Vector3(x + offsetX, -y + offsetY, 0);
                }

                // if (c == 'P')
                // {
                //     newObj = Instantiate<GameObject>(prefabPlayer);
                //     newObj.transform.position = 
                //         new Vector3(x + offsetX, -y + offsetY, 0);
                // }else if (c == 'W')
                // {
                //     newObj = Instantiate<GameObject>(prefabWall);
                //     newObj.transform.position =
                //         new Vector3(x + offsetX, -y + offsetY, 0);
                // }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
