using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPresent : MonoBehaviour {

    public Vector3 newposition;
    public Vector3 newrotation;
    public int count;
    public AudioSource OpenBox;

    // Use this for initialization
    void Start () {
        count = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player") && count==1)
        {
            count++;
            Vector3 oldposition = gameObject.transform.position;
            gameObject.transform.Rotate(newrotation);
            gameObject.transform.position = oldposition + newposition;
            Debug.Log(oldposition);
            Debug.Log(oldposition + newposition);
            Debug.Log(newrotation);
            OpenBox.Play();
            gameObject.SetActive(true);
        }

    }
}
