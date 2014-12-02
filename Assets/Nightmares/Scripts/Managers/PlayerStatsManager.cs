using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatsManager : MonoBehaviour
{
    public Text level;
    public Text experience;
    public Text highestScore;

    void Update()
    {
        highestScore.text = ScoreManager.highestScore.ToString();
    }

    public void SetLevel(string playerLevel)
    {
        level.text = playerLevel;
    }

    public void SetExperience(string current, string next)
    {
        experience.text = current + " / " + next;
    }
}
