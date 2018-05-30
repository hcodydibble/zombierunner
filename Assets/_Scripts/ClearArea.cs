using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearArea : MonoBehaviour {
    
	public float timeSinceLastTrigger = 0f;
    private int triggersInCollider;
    private bool foundClearedArea = false;

	private void Update()
	{
        if(triggersInCollider > 0)
        {
            timeSinceLastTrigger = 0f;
        }

        timeSinceLastTrigger += Time.deltaTime / 2;

        if (timeSinceLastTrigger > 1f && Time.realtimeSinceStartup > 10 && !foundClearedArea)
        {
            SendMessageUpwards("OnFindClearArea");
            foundClearedArea = true;
        }
	}

	private void OnTriggerEnter(Collider other)
	{
        triggersInCollider++;
	}

	private void OnTriggerExit(Collider other)
	{
        triggersInCollider--;
	}
}
