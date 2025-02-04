using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;

    public int Score
    {
        set
        {
            score = value;
            Debug.Log("New score: " + score);

            if (targetScore == score)
            {
                targetScore *= 3;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            if (score > HighScore)
            {
                HighScore = score;
            }
            
            displayText.text = "Score: " + score + " High Score: " + HighScore;
        }
        get
        {
            return score;
        }
    }

    private const string KeyHighScore = "HIGH_SCORE";
    
    private int highScore;

    public int HighScore
    {
        set
        {
            highScore = value;

            if (!File.Exists(filePathHighScore))
            {
                string dirLocation = Application.dataPath + DirName;

                if (!Directory.Exists(dirLocation))
                {
                    Directory.CreateDirectory(dirLocation);
                }
            }

            File.WriteAllText(filePathHighScore, score + "");
            //PlayerPrefs.SetInt(KeyHighScore, highScore);
        }
        get
        {
            if (File.Exists(filePathHighScore))
            {
                string fileContents = File.ReadAllText(filePathHighScore);
                
                highScore = int.Parse(fileContents);
            }

            //highScore = PlayerPrefs.GetInt(KeyHighScore, 0);
            return highScore;
        }
    }

    string filePathHighScore;
    const string DirName = "/Data/";
    const string FileName = DirName + "highScore.txt";

    public int targetScore = 3;

    TextMeshProUGUI displayText;
    
    //the static instance that holds the sole object of this Singleton
    public static GameManager instance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Vector3 newVec = UtilScript.CloneVec3(Vector3.down);
        
        //check to see if someone has set the instance
        if (instance == null)
        {
            //if they haven't this is the instance
            instance = this;
            //and keep it around in other scenes
            DontDestroyOnLoad(this);
            
            displayText =
                GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
            
            Debug.Log(Application.dataPath);

            filePathHighScore = Application.dataPath + FileName;

            Score = 0;
            
            Debug.Log(filePathHighScore);
        }
        else //otherwise, if there is an existing instance
        {
            //destroy the new instance that was just created
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);

    }

    public void UpdateScore()
    {
        
    }
}
