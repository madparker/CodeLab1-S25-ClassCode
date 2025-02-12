using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{ 
    public static GameManager instance;

    public Timer timer;

    int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    [SerializeField] List<int> highScores;

    const string fileName = "highScores.txt";
    string filePath = "";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        timer = GetComponent<Timer>();
        
        filePath = Application.dataPath + "/Data/" + fileName;

        //if there's a file
        if (File.Exists(filePath))
        {
            //get the contents of the file
            string fileContents = File.ReadAllText(filePath);
            //split them up
            string[] lines = fileContents.Split(',');

            //parse the values into ints and put them into the highScore list
            foreach (var line in lines)
            {
                highScores.Add(int.Parse(line));
            }
        }
        else //if there is no file
        {
            //set the highScores to default values
            for (int i = 0; i < 10; i++)
            {
                highScores.Add(10 - i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHighScores()
    {
        //go through all the high scores
        for (int i = 0; i < highScores.Count; i++)
        {
            int currentHS = highScores[i];

            //if the high score is lower or equal to the current score
            if (score >= currentHS)
            {
                //put the current high score in the list where we found the lower score
                highScores.Insert(i, score);
                break;
            }
        }

        //if we have more than 10 high scores
        if (highScores.Count > 10)
        {
            //remove the lowest one, which is at the end
            highScores.RemoveAt(highScores.Count - 1);
        }
        
        string fileContents = "";
        
        //go through all the high scores
        foreach (var scoreData in highScores)
        {
            //add the current score, plus the string "," to the fileContents
            fileContents += scoreData + ",";
        }
        
        //save file contents to a file
        File.WriteAllText(filePath, fileContents);
    }
}
