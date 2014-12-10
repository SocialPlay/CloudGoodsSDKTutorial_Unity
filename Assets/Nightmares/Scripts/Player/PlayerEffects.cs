using UnityEngine;
using System.Collections;

public class PlayerEffects : MonoBehaviour
{
    public GameObject speedUpEffectPrefab;

    bool playerSpeedApplied = false;

    PlayerHealth playerHealth;
    PlayerMovement playerMovement;

    AutoTimer playerSpeedTimer = new AutoTimer(0);

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerSpeedTimer.IsDone())
        {
            playerMovement.speed = 6;

            playerSpeedApplied = false;
        }
    }

    void ActivateSpeedUpEffect()
    {

    }

    void DeactivateSpeedUpEffect()
    {

    }

    public bool canPlayerBeHealed()
    {
        return playerHealth.currentHealth < playerHealth.startingHealth;
    }

    public bool canPlayerGetSpeedUp()
    {
        return !playerSpeedApplied;
    }

    public void HealPlayer(int power)
    {
        int healAmount = power + Random.Range(1, 5);

        if ((playerHealth.currentHealth + healAmount) >= playerHealth.startingHealth)
        {
            playerHealth.currentHealth = playerHealth.startingHealth;
        }
        else
        {
            playerHealth.currentHealth += healAmount;
        }
    }

    public void SetPlayerSpeed(float power)
    {
        playerMovement.speed += power;

        playerSpeedApplied = true;

        playerSpeedTimer.Reset(10);
    }
}
