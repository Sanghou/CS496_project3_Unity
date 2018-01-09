 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject ExplosionEffect;
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    float countdown;
    bool hasExploded = false;

	// Use this for initialization
	void Start () {
        countdown = delay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
            Debug.Log("Boom!");
        }
	}

    void Explode()
    {
        Debug.Log("IN!");
        //show effect
        Instantiate(ExplosionEffect, transform.position, transform.rotation);
        //get nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);
        foreach(Collider nearbyObject in colliders)
        {
            //add force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            Destructible doorbreak = nearbyObject.GetComponent<Destructible>();
            if(doorbreak != null)
            {
                doorbreak.Destroy();
            }
        }
        //remove bomb
        Destroy(gameObject);
    }
}
