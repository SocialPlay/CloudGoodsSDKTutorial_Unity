using UnityEngine;
using System.Collections;

public class AutoTimer
{
    public float length;
    public float current;

    bool paused = false;

    public bool IsDone()
    {
        if (current >= length)
        {
            return true;
        }

        if (!paused)
        {
            current += Time.deltaTime;
        }
        
        return false;
    }

    public void Pause(bool state)
    {
        paused = state;
    }

    public void Reset()
    {
        current = 0;
    }

    public void Reset(float length)
    {
        this.length = length;
        current = 0;
    }

    public AutoTimer(float length)
    {
        this.length = length;
        current = 0;
    }
}
