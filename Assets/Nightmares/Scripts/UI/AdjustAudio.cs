using UnityEngine;
using System.Collections;

public class AdjustAudio : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (PauseManager.IsPaused || PlayerHealth.IsDead)
        {
            audioSource.volume = 0.03f;
        }
        else
        {
            audioSource.volume = 0.1f;
        }
    }
}
