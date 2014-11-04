using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PausedTextController : MonoBehaviour
{
    Color textColor;
    Text pauseText;

	void Awake ()
    {
        pauseText = GetComponent<Text>();
        textColor = pauseText.color;
	}

    void Update()
    {
        if (PauseManager.IsPaused && !PlayerHealth.IsDead)
        {
            textColor.a = 1;
        }
        else
        {
            textColor.a = 0;
        }

        pauseText.color = textColor;
    }
}