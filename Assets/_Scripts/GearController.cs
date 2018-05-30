using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour {

    public GameObject flashlight;
    public GameObject pistol;

    bool flashlightToggled = false;
    bool pistolToggled = false;

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Flashlight"))
        {
            ToggleFlashlight();
        }

        if(Input.GetButtonDown("Pistol"))
        {
            TogglePistol();
        }
	}

    void ToggleFlashlight()
    {
        if(pistolToggled)
        {
            pistol.SetActive(false);
            pistolToggled = false;
        }

        if (flashlightToggled)
        {
            flashlight.SetActive(false);
            flashlightToggled = false;
        }
        else
        {
            flashlight.SetActive(true);
            flashlightToggled = true;
        }
    }

    void TogglePistol()
    {
        if(flashlightToggled)
        {
            flashlight.SetActive(false);
            flashlightToggled = false;
        }

        if(pistolToggled)
        {
            pistol.SetActive(false);
            pistolToggled = false;
        }
        else
        {
            pistol.SetActive(true);
            pistolToggled = true;
        }
    }
}
