using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{


    public GameObject zombiePrefab;
    public LayerMask mask = -1;

    private int maxZombieCount = 50;

    private void Update()
    {
        if (transform.childCount >= 50)
        {
            CancelInvoke();
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            StartCoroutine(SpawnZombies());
        }
    }

    private IEnumerator SpawnZombies()
    {
        while (transform.childCount < maxZombieCount)
        {
            yield return new WaitForSeconds(1);

            Vector3 random = Random.insideUnitSphere * 200;
            Vector3 pos = new Vector3(transform.position.x + random.x, transform.position.y, transform.position.z + random.z);

            RaycastHit hit;

            if(Physics.Raycast(pos, Vector3.down, out hit, mask))
            {
                if(hit.collider.GetComponent<Terrain>())
                {
                    GameObject zombie = Instantiate(zombiePrefab, hit.point, Quaternion.identity) as GameObject;
                    zombie.transform.parent = transform;
                }
            }
        }
    }
}
