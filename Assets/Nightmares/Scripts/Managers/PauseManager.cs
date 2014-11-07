using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PauseManager : MonoBehaviour
{
    public KeyCode primaryPauseKey = KeyCode.Escape;
    public KeyCode secondaryPauseKey = KeyCode.Tab;

    static bool isPaused = false;

    public static bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    static bool isPauseDisabled = false;

    public static bool IsPauseDisabled
    {
        get { return isPauseDisabled; }
        set { isPauseDisabled = value; }
    }

    void Update()
    {
        if (isPauseDisabled)
        {
            return;
        }

        if (PlayerHealth.IsDead)
        {
            isPaused = true;
            return;
        }

        if (Input.GetKeyDown(primaryPauseKey) || Input.GetKeyDown(secondaryPauseKey))
        {
            isPaused = !isPaused;
        }
    }

    public void TogglePauseFunction()
    {
        isPauseDisabled = !isPauseDisabled;
    }
}

