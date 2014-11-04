﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginManager : MonoBehaviour {
    public UnityUICloudGoodsLogin loginSystem;
    public DisplayStoreItems displayStoreItems;

    public Button logoutButton;
    public Button shopButton;
    public Button startGameButton;
    public Button buyCreditsButton;

    public Text welcomeMessage;

    void Awake()
    {
        CloudGoods.OnUserAuthorized += CloudGoods_OnUserAuthorized;
    }

    void CloudGoods_OnUserAuthorized(CloudGoodsUser player)
    {
        welcomeMessage.text = "Welcome " + player.userName + "\n" + player.userEmail;

        Initialize();

        ActivateButtons();
    }

    void Initialize()
    {
        displayStoreItems.DisplayItems();
    }

    void ActivateButtons()
    {
        startGameButton.interactable = true;
        shopButton.interactable = true;
        logoutButton.interactable = true;
        buyCreditsButton.interactable = true;
    }

    void DisableButtons()
    {
        startGameButton.interactable = false;
        shopButton.interactable = false;
        logoutButton.interactable = false;
        buyCreditsButton.interactable = false;
    }

    public void LogoutPlayer()
    {
        CloudGoods.Logout();

        loginSystem.gameObject.SetActive(true);
        loginSystem.loginUserPassword.value = string.Empty;
        loginSystem.loginUserPassword.text.text = string.Empty;
        loginSystem.loginErrorLabel.text = string.Empty;

        DisableButtons();

        welcomeMessage.text = "Player has logged out.";
    }
}