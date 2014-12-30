using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginManager : MonoBehaviour {
    public UnityUICloudGoodsLogin loginSystem;

    public Button logoutButton;
    public Button shopButton;
    public Button startGameButton;

    public Text welcomeMessage;

    void Awake()
    {
        DisableButtons();
        OpenLoginSystem();
    }

    void OnEnable()
    {
        CloudGoods.OnUserAuthorized += CloudGoods_OnUserAuthorized;
    }

    void OnDisable()
    {
        CloudGoods.OnUserAuthorized -= CloudGoods_OnUserAuthorized;
    }

    void CloudGoods_OnUserAuthorized(CloudGoodsUser player)
    {
        if (welcomeMessage != null)
        {
            welcomeMessage.text = "Welcome " + player.userName + "\n" + player.userEmail;
        }

        ActivateButtons();
    }

    void OpenLoginSystem()
    {
        if (!loginSystem.loginTab.activeInHierarchy && !UserAlreadyLoggedIn())
        {
            loginSystem.loginTab.SetActive(true);
        }
    }

    void ActivateButtons()
    {
        startGameButton.interactable = true;
        shopButton.interactable = true;
        logoutButton.interactable = true;
    }

    void DisableButtons()
    {
        startGameButton.interactable = false;
        shopButton.interactable = false;
        logoutButton.interactable = false;
    }

    bool UserAlreadyLoggedIn()
    {
        return CloudGoods.isLogged;
    }

    public void LogoutPlayer()
    {
        CloudGoods.Logout();

        loginSystem.SwitchToLogin();

        DisableButtons();

        welcomeMessage.text = "Player has logged out.";
    }
}
