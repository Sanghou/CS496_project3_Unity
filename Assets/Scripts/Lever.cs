using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public Animator anim;
    public KeyCode push;
    public bool pushed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(push))
        {
            Debug.Log("pushing");
            pushed = true;
            
        } else
        {
            pushed = false;
        }
        anim.SetBool("lever_pushed", pushed);
    }

    private void OnTriggerExit(Collider other)
    {
        pushed = false;
        anim.SetBool("lever_pushed", pushed);
    }
}
