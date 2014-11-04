using UnityEngine;
using System.Collections;

public class AutoTimer
{
    public float length;
    public float current;

    public bool IsDone()
    {
        if (current >= length)
        {
            return true;
        }
        current += Time.deltaTime;
        return false;
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
