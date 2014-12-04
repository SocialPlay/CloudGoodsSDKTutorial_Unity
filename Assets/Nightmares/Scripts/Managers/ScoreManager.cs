using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;        // The player's score.
    static int highestScore;
    static int highScoreBackup;


    public Text text;                      // Reference to the Text component.
    public Text highestText;

    AutoTimer saveHighestScoreTimer;

    void Awake()
    {
        saveHighestScoreTimer = new AutoTimer(60);

        // Reset the score.
        score = 0;
        highestScore = 0;

        UserDataManager.UserDataReady += UserDataManager_UserDataReady;
    }

    void UserDataManager_UserDataReady(PlayerData playerData)
    {
        SetHighestScore(playerData.hiScore);
    }

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value.
        text.text = "Score: " + score;

        if (score > highestScore)
        {
            highestScore = score;
        }

        highestText.text = "Highest: " + highestScore;

        //check if highscore has been beat
        if (highestScore != highScoreBackup)
        {
            //Save score every minute
            if (saveHighestScoreTimer.IsDone())
            {
                UserDataManager.SaveUserHighestScore(highestScore.ToString());

                highScoreBackup = highestScore;

                saveHighestScoreTimer.Reset();
            }
        }
    }

    public static string GetHighestScore()
    {
        return highestScore.ToString();
    }

    public static void SetHighestScore(int score)
    {
        highestScore = score;
        highScoreBackup = score;
    }
}