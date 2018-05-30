using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour {
    
    public Light sun;
    public float secondsInFullDay = 120f;
    [Range(0, 1)]
    public float currentTimeOfDay;
    [HideInInspector]
    public float timeMultplier = 1f;

    float sunInitialIntensity;
    float fogInitialDensity;

	// Use this for initialization
	void Start () {
        sunInitialIntensity = sun.intensity;
        fogInitialDensity = RenderSettings.fogDensity;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultplier;

        if(currentTimeOfDay >= 1)
        {
            currentTimeOfDay = 0;
        }
	}

    void UpdateSun()
    {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1f;
        if(currentTimeOfDay <= 0.23f || currentTimeOfDay >=0.75f)
        {
            intensityMultiplier = 0;
        }
        else if(currentTimeOfDay <= 0.25f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.23f) * (1 / 0.02f)));

        }
        else if(currentTimeOfDay >= 0.73f)
        {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}
