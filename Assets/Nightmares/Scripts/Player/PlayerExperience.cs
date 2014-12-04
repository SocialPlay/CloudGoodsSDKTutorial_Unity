using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerExperience : MonoBehaviour
{
    public Slider playerXp;
    public Text playerLevel;

    public int level = 1;
    public int totalExperience = 0;

    AutoTimer saveXpTimer;

    void Awake()
    {
        saveXpTimer = new AutoTimer(60);

        UserDataManager.UserDataReady += UserDataManager_UserDataReady;
    }

    void UserDataManager_UserDataReady(PlayerData playerData)
    {
        InitializePlayerExperience(playerData);
    }

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

        if (saveXpTimer.IsDone())
        {
            UserDataManager.SaveUserExperience(totalExperience.ToString());

            saveXpTimer.Reset();
        }
    }

    void InitializePlayerExperience(PlayerData playerData)
    {
        SetPlayerLevel(playerData.level);
        SetPlayerExperience(playerData.xp);
    }

    void SetPlayerLevel(int newLevel)
    {
        level = newLevel;

        playerXp.maxValue = getNewNextLevelValue(level);

        PlayerStatsManager.SetLevel(level.ToString());
    }

    void SetPlayerExperience(int newExperience)
    {
        totalExperience = newExperience;
        playerXp.value = totalExperience;

        PlayerStatsManager.SetExperience(totalExperience + " / " + playerXp.maxValue);
    }

    int getNewNextLevelValue(int receivedLevel)
    {
        return receivedLevel * 25;
    }

    void LevelUp()
    {
        playerXp.value = 0;

        int remainingXp = Mathf.Abs(Mathf.RoundToInt(playerXp.maxValue) - totalExperience);

        totalExperience = remainingXp;

        level++;

        playerXp.maxValue = getNewNextLevelValue(level);

        UserDataManager.SaveUserLevel(level.ToString());
        UserDataManager.SaveUserExperience(totalExperience.ToString());

        PlayerStatsManager.SetLevel(level.ToString());
        PlayerStatsManager.SetExperience(totalExperience + " / " + playerXp.maxValue);
    }

    public void AddExperience()
    {
        float randomModifier = Random.Range(1, 10);
        float secondRandomModifier = Random.Range(0.1f, 1.0f);
        float amount = secondRandomModifier * randomModifier;

        totalExperience += Mathf.CeilToInt(amount);

        PlayerStatsManager.SetExperience(totalExperience + " / " + playerXp.maxValue);
    }
}
