using UnityEngine;
using System.Collections;

public class PlayerPaused : MonoBehaviour
{
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;

	void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
	}

    void Update()
    {
        playerMovement.enabled = !PauseManager.IsPaused && !PlayerHealth.IsDead;
        playerShooting.enabled = !PauseManager.IsPaused && !PlayerHealth.IsDead;
    }
}
