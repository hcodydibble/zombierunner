using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

    private bool dispatched = false;
    private Rigidbody helicopterRigidbody;

	// Use this for initialization
	void Start () {
        helicopterRigidbody = GetComponent<Rigidbody>();
	}
	

    void OnDispatchHelicopter()
    {
        if (!dispatched)
        {
            dispatched = true;
            helicopterRigidbody.velocity = new Vector3(0, 0, 50f);
        }
    }
}
