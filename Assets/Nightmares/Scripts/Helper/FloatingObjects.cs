using UnityEngine;
using System.Collections;

public class FloatingObjects : MonoBehaviour
{
    public static Transform _transform = null;

    void Awake()
    {
        _transform = gameObject.transform;
    }
}
