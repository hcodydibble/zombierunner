using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolController : MonoBehaviour {
    public AudioClip gunFire;
    public AudioClip gunWield;

    private Transform bulletSpawn;
    private Animator pistolAnimator;
    private AudioSource audioSource;
    private GameObject currentTarget;
    private float timeBetweenShots = 0.3333f;
    private float timestamp;

	// Use this for initialization
	void Start () {
        pistolAnimator = GetComponent<Animator>();
        bulletSpawn = transform.Find("Bullet Spawn");
        audioSource = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if (Time.time >= timestamp && Input.GetButtonDown("Fire1"))
        {
            Fire();
            timestamp = Time.time + timeBetweenShots;
        }
    }

    public void Fire()
    {
        //GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        int bulletDamage = 20;
        Ray ray = new Ray(bulletSpawn.position, bulletSpawn.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 20))
        {
            if (hitInfo.collider.name == "Zombie(Clone)")
            {
                GameObject target = hitInfo.collider.gameObject;
                Health targetHealth = target.GetComponent<Health>();
                if(targetHealth)
                {
                    targetHealth.DealDamage(bulletDamage);
                }
            }
        }
        audioSource.clip = gunFire;
        audioSource.Play();
        pistolAnimator.SetTrigger("firing");
        //bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
        //Destroy(bullet, 2.0f);
    }

    public void PlayWieldSound()
    {
        audioSource.clip = gunWield;
        audioSource.Play();
    }
}
