using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{

    private Camera eyes;
    private Transform playerLoc;
    private float defaultFOV;

    // Use this for initialization
    void Start()
    {
        eyes = GetComponent<Camera>();
        defaultFOV = eyes.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        playerLoc = transform.parent.gameObject.transform;

        if (Input.GetButton("Fire2"))
        {
            eyes.fieldOfView = defaultFOV / 1.5f;
        }
        else
        {
            eyes.fieldOfView = defaultFOV;
        }

        if (playerLoc.position.y < 47)
        {
            eyes.clearFlags = CameraClearFlags.SolidColor;
        }else
        {
            eyes.clearFlags = CameraClearFlags.Skybox;
        }
    }



}