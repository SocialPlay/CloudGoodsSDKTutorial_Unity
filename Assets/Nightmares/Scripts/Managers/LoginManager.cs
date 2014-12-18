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

        CloudGoods.OnUserAuthorized += CloudGoods_OnUserAuthorized;
    }

    void CloudGoods_OnUserAuthorized(CloudGoodsUser player)
    {
        if (welcomeMessage != null)
        {
            welcomeMessage.text = "Welcome " + player.userName + "\n" + player.userEmail;
        }

        ActivateButtons();
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

    public void LogoutPlayer()
    {
        CloudGoods.Logout();

        loginSystem.SwitchToLogin();

        DisableButtons();

        welcomeMessage.text = "Player has logged out.";
    }
}
