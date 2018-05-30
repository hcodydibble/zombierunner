using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //public Transform playerSpawnPoints;
    public GameObject landingAreaPrefab;

    private Transform[] spawnPoints;
    private bool respawn = false;
    private bool lastToggle = false;

	void Start () {
        //spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();
	}

	private void Update()
	{
        //if(transform.position.y < 47)
        //{
        //    Respawn();
        //    respawn = false;
        //}
        //if (lastToggle != respawn)
        //{
        //    Respawn();
        //    respawn = false;
        //}
        //else
        //{
        //    lastToggle = respawn;
        //}
	}

	private void Respawn()
    {
        int randNum = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[randNum].transform.position;
    }

    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
    }

    void DropFlare(){
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
    }
}
