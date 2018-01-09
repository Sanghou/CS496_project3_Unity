using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPresent : MonoBehaviour {

    public Vector3 newposition;
    public Vector3 newrotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            Vector3 oldposition = gameObject.transform.position;
            gameObject.transform.Rotate(newrotation);
            gameObject.transform.position = oldposition + newposition;
            Debug.Log(oldposition);
            Debug.Log(oldposition + newposition);
            Debug.Log(newrotation);
            gameObject.SetActive(true);
        }

    }
}
