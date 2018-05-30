using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health = 100;

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DealDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            animator.SetTrigger("isDead");
            Debug.Log(name + " is dead");
            Invoke("DestroyObject", 0.8f);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
