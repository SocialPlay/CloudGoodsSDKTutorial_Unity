using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TopScoreManager : MonoBehaviour
{
    public Text loadingText;

    public List<PlayerScore> playerScores = new List<PlayerScore>();
    public Text[] scoreSlots;

	void Start()
    {
        //CloudGoods.RetriveAllUserDataOfKey("highscores", ReceivedAllUserData);
	}

    void ReceivedAllUserData(List<UserDataValue> userData)
    {
        loadingText.enabled = false;

        foreach (UserDataValue item in userData)
        {
            Debug.Log(userData.IndexOf(item) + " " + item.user + " : " + item.value);
        }

        if (playerScores.Count < 1) return;

        for (int i = 0; i < scoreSlots.Length; i++)
        {
            if (i > playerScores.Count) break;

            scoreSlots[i].text = i + ". " + playerScores[i].name + " : " + playerScores[i].score;
        }
    }
}

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;
}