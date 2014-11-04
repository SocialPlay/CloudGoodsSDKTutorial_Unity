using UnityEngine;
using System.Collections;

public class DestroyThisObject : MonoBehaviour {
    public float timer = 2f;

	void Start () {
        Destroy(gameObject, timer);
	}
}
