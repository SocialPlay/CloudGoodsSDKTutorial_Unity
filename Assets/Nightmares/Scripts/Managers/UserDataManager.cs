using UnityEngine;
using System.Collections;

public class UserDataManager : MonoBehaviour
{
    public static event System.Action<PlayerData> UserDataReady;

    int dataPlayerLevel = 1;
    int dataPlayerExperience = 0;
    int dataPlayerScore = 0;

    bool lvlReady = false,
        xpReady = false,
        hiScoreReady = false;

    void OnLevelWasLoaded(int level)
    {
        GameObject testUserLogin = GameObject.Find("Test User Login");
        if (testUserLogin != null) Destroy(testUserLogin);

        InitializeUserData();
    }

    void Awake()
    {
        CloudGoods.OnUserAuthorized += CloudGoods_OnUserAuthorized;
    }

    void CloudGoods_OnUserAuthorized(CloudGoodsUser obj)
    {
        InitializeUserData();
    }

    void InitializeUserData()
    {
        CloudGoods.RetrieveUserDataValue("lvl", ReceivedUserLevel);
        CloudGoods.RetrieveUserDataValue("xp", ReceivedUserExperience);
        CloudGoods.RetrieveUserDataValue("highScore", ReceivedUserHighScore);
    }

    void ReceivedUserLevel(string lvl)
    {
        string loadedLevel = "1";

        if (string.IsNullOrEmpty(lvl))
        {
            CloudGoods.SaveUserData("lvl", "1", null);
        }
        else
        {
            loadedLevel = lvl;
        }

        dataPlayerLevel = int.Parse(loadedLevel);
        lvlReady = true;
    }

    void ReceivedUserExperience(string xp)
    {
        string loadedXP = "0";

        if (string.IsNullOrEmpty(xp))
        {
            CloudGoods.SaveUserData("xp", "0", null);
        }
        else
        {
            loadedXP = xp;
        }

        dataPlayerExperience = int.Parse(loadedXP);
        xpReady = true;
    }

    void ReceivedUserHighScore(string hiScore)
    {
        string loadedHighScore = "0";

        if (string.IsNullOrEmpty(hiScore))
        {
            CloudGoods.SaveUserData("highScore", "0", null);
        }
        else
        {
            loadedHighScore = hiScore;
        }

        dataPlayerScore = int.Parse(loadedHighScore);
        hiScoreReady = true;
    }

    void Update()
    {
        if (hiScoreReady && xpReady && lvlReady)
        {
            lvlReady = false;
            xpReady = false;
            hiScoreReady = false;

            if (UserDataReady != null) UserDataReady(GetPlayerData());
        }
    }

    public PlayerData GetPlayerData()
    {
        PlayerData playerData = new PlayerData();

        playerData.hiScore = dataPlayerScore;
        playerData.level = dataPlayerLevel;
        playerData.xp = dataPlayerExperience;

        return playerData;
    }

    public static void SaveUserHighestScore(string score)
    {
        CloudGoods.SaveUserData("highScore", score, null);
    }

    public static void SaveUserLevel(string level)
    {
        CloudGoods.SaveUserData("lvl", level, null);
    }

    public static void SaveUserExperience(string experience)
    {
        CloudGoods.SaveUserData("xp", experience, null);
    }
}

[System.Serializable]
public class PlayerData
{
    public int level = 1;
    public int xp = 0;
    public int hiScore = 0;
}
