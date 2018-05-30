using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

    public AudioClip whatHappened;
    public AudioClip goodLandingArea;

    private AudioSource audioSource;

	private void Start()
	{
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = whatHappened;
        audioSource.Play();
	}

    void OnFindClearArea()
    {
        audioSource.clip = goodLandingArea;
        audioSource.Play();

        Invoke("CallHelicopter", goodLandingArea.length + 1f);
    }

    void CallHelicopter()
    {
        SendMessageUpwards("OnMakeInitialHeliCall");
    }
}
