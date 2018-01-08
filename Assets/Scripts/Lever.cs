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
            //pushed = !pushed;
            anim.SetBool("lever_pushed", true);
        } else
        {
            anim.SetBool("lever_pushed", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("lever_pushed", false);
    }
}
