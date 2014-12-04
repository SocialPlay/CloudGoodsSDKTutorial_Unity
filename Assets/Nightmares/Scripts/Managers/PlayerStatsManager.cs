using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatsManager : MonoBehaviour
{
    public Text level;
    public Text experience;

    static string levelText = string.Empty;
    static string experienceText = string.Empty;

    void Update()
    {
        level.text = levelText;
        experience.text = experienceText;
    }

    public static void SetLevel(string playerLevel)
    {
        levelText = playerLevel;
    }

    public static void SetExperience(string newExperience)
    {
        experienceText = newExperience;
    }
}
