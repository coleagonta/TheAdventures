using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]

public class enemy : MonoBehaviour
{
    [Header("Player")] public Transform myPlayer;

    [Header("Audio")] public AudioClip myClip;

    [Header("Teg")] public string myTag = "Player";

    [Header("Score")] public int myNumber = 10;

    public void Update()
    {
        transform.LookAt(myPlayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == myTag)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(myClip);
            }

            if (myPlayer != null)
            {
                LevelHealth levelHealth = myPlayer.GetComponent<LevelHealth>();
                if (levelHealth != null)
                {
                    levelHealth.levelHealth -= myNumber;
                }
            }

            Debug.Log("attack");
        }
    }
}


       
