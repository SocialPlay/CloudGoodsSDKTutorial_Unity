using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    Animator anim;                          // Reference to the animator component.

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        // If the player has run out of health...
        if (PlayerHealth.IsDead)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");
        }
    }

    void ResetStaticGameData()
    {
        PlayerHealth.IsDead = false;
        PauseManager.IsPauseDisabled = false;
        PauseManager.IsPaused = false;
    }

    public void RestartGame()
    {
        // Reload the currently loaded level.
        ResetStaticGameData();
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitGame()
    {
        // Load the title menu.
        ResetStaticGameData();
        Application.LoadLevel(0);
    }
}
