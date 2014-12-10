﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class TopScoreManager : MonoBehaviour
{
    public string highScoreUserDataKey = "highScore";
    public Button refreshScoreButton;
    public Animator refreshButtonAnim;
    public Text loadingText;

    public List<PlayerScore> playerScores = new List<PlayerScore>();
    public Text[] scoreSlots;

    AutoTimer refreshButtonEnableTimer = new AutoTimer(10);

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
        refreshButtonEnableTimer.Reset();
        refreshScoreButton.interactable = false;
        refreshButtonAnim.SetTrigger("play");

        CloudGoods.RetrieveAllUserDataOfKey(highScoreUserDataKey, ReceivedAllUserData);
    }

    void ReceivedAllUserData(List<MultipleUserDataValue> userData)
    {
        if (userData == null) return;

        List<MultipleUserDataValue> playerData = userData;

        SetHighScores(playerData);
    }

    void Update()
    {
        if (refreshButtonEnableTimer.IsDone())
        {
            refreshScoreButton.interactable = true;
        }
    }

    void SetHighScores(List<MultipleUserDataValue> playerData)
    {
        playerScores.Clear(); // clear current player scores.

        foreach (MultipleUserDataValue item in playerData)
        {
            PlayerScore ps = new PlayerScore();
            ps.name = item.user.userName;
            ps.score = int.Parse(item.value);

            playerScores.Add(ps);
        }

        refreshButtonAnim.SetTrigger("stop");

        if (playerScores.Count < 1)
        {
            loadingText.text = "no player scores available";
            return;
        }

        playerScores.Sort((px, py) => px.score.CompareTo(py.score));
        playerScores.Reverse();

        for (int i = 0; i < scoreSlots.Length; i++)
        {
            if (i > playerScores.Count) break;

            SetScoreSlotText(i, (i + 1) + ". " + playerScores[i].name + " : " + playerScores[i].score);
        }

        loadingText.enabled = false;
    }

    void SetScoreSlotText(int index, string text)
    {
        scoreSlots[index].text = text;
    }

    public void RefreshHighScores()
    {
        InitializeTopScores();

        for (int i = 0; i < scoreSlots.Length; i++)
        {
            SetScoreSlotText(i, "");
        }

        loadingText.enabled = true;
        loadingText.text = "retrieving player scores";
    }
}

[System.Serializable]
public class PlayerScore
{
    public string name;
    public int score;
}