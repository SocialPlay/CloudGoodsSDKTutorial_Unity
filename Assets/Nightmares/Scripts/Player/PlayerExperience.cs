using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerExperience : MonoBehaviour
{
    public Slider playerXp;
    public Text playerLevel;
    public PlayerStatsManager playerStatsManager;

    public int level = 1;
    public int totalExperience = 0;

    void Update()
    {
        playerLevel.text = level.ToString();

        if (playerXp.value == playerXp.maxValue)
        {
            LevelUp();
        }

        if (playerXp.value != totalExperience)
        {
            playerXp.value++;
        }
    }

    void LevelUp()
    {
        playerXp.value = 0;

        int remainingXp = Mathf.Abs(Mathf.RoundToInt(playerXp.maxValue) - totalExperience);

        totalExperience = remainingXp;

        level++;

        playerXp.maxValue += (playerXp.maxValue / 2);

        playerStatsManager.SetLevel(level.ToString());
        playerStatsManager.SetExperience(totalExperience.ToString(), playerXp.maxValue.ToString());
    }

    public void AddExperience()
    {
        int randomModifier = Random.Range(1, 10);
        int receivedXPModifier = level;
        int amount = receivedXPModifier * randomModifier;

        totalExperience += Mathf.RoundToInt(amount / 2);

        playerStatsManager.SetExperience(totalExperience.ToString(), playerXp.maxValue.ToString());
    }
}
