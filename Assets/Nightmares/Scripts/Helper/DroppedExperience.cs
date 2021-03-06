﻿using UnityEngine;
using System.Collections;

public class DroppedExperience : MonoBehaviour
{
    GameObject player;

    AutoTimer timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        timer = new AutoTimer(0.5f);

        Vector3 force = new Vector3(Random.Range(-10, 10), 15, Random.Range(-10, 10));
        rigidbody.AddForce(force * 10);
    }

    void Update()
    {
        if (!timer.IsDone()) return;

        if (rigidbody) Destroy(gameObject.rigidbody);

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 15 * Time.deltaTime);
    }

    public void ReceivedExperience()
    {
        //possibly instantiate particle effect.

        Destroy(gameObject, 0.3f);
    }
}
