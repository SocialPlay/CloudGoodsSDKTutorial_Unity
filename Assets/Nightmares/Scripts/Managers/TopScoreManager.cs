using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TopScoreManager : MonoBehaviour
{
    public string highScoreUserDataKey = "highScore";
    public Text loadingText;

    public List<PlayerScore> playerScores = new List<PlayerScore>();
    public Text[] scoreSlots;

    void OnLevelWasLoaded(int scene)
    {
        InitializeTopScores();
    }

	void Awake()
    {
        CloudGoods.OnUserAuthorized += CloudGoods_OnUserAuthorized;
	}

    void CloudGoods_OnUserAuthorized(CloudGoodsUser obj)
    {
        InitializeTopScores();
    }

    void InitializeTopScores()
    {
        CloudGoods.RetrieveAllUserDataOfKey(highScoreUserDataKey, ReceivedAllUserData);
    }

    void ReceivedAllUserData(List<UserDataValue> userData)
    {
        Debug.Log("got all users high score data");
        if (userData == null) return;

        foreach (UserDataValue item in userData)
        {
            PlayerScore ps = new PlayerScore();
            ps.name = item.user.userName;
            ps.score = int.Parse(item.value);

            playerScores.Add(ps);
        }

        if (playerScores.Count < 1)
        {
            loadingText.text = "No player scores available.";
            return;
        }

        playerScores.Sort((px, py) => px.score.CompareTo(py.score));
        playerScores.Reverse();

        for (int i = 0; i < scoreSlots.Length; i++)
        {
            if (i > playerScores.Count) break;

            scoreSlots[i].text = (i + 1) + ". " + playerScores[i].name + " : " + playerScores[i].score;
        }

        loadingText.enabled = false;
    }
}

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;
}