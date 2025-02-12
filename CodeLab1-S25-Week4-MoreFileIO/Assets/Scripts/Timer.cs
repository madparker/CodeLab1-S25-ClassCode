using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerDisplay;

    public int gameTime = 10;

    public int currentTime = 0;

    public const string TimerTick = "UpdateTimer";
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerDisplay.text = TimerString(gameTime);
        
        //Invoke(TimerTick, 1);
        InvokeRepeating(TimerTick, 1, 1);
    }

    public void UpdateTimer()
    {
        currentTime++;

        //If we've reached the end of game time, end game
        if (currentTime == gameTime)
        {
            GameManager.instance.UpdateHighScores();
            timerDisplay.text = "GAME OVA";
            CancelInvoke(TimerTick); //stop invoke because game is over
        }
        else
        {
            timerDisplay.text = TimerString(gameTime - currentTime);
            //Invoke(TimerTick, 1);
        }
    }

    //Function that returns a string for the score and time
    string TimerString(int timeInt)
    {
        string result = "";

        result = "Time: " + timeInt + " Score: " + GameManager.instance.Score;

        return result;
    }
}
