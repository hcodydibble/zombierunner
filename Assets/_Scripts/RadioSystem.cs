﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystem : MonoBehaviour {

    public AudioClip initialHeliCall;
    public AudioClip initialCallReply;

    private AudioSource audioSource;

	private void Start()
	{
        audioSource = GetComponent<AudioSource>();
	}

    void OnMakeInitialHeliCall()
    {
        audioSource.clip = initialHeliCall;
        audioSource.Play();

        Invoke("InitialReply", initialHeliCall.length + 1f);
    }

    void InitialReply()
    {
        audioSource.clip = initialCallReply;
        audioSource.Play();
        BroadcastMessage("OnDispatchHelicopter");
    }
}
