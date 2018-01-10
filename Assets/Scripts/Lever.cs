using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour {

    public Animator anim;
    public KeyCode push;
    public bool pushed;

    public UnityEvent pushEvent;
    public UnityEvent popEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //for debug
        //pushEvent.Invoke();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            push = other.GetComponent<Character>().pickup;
            if (Input.GetKey(push))
            {
                pushed = true;
                pushEvent.Invoke();
            }
            else
            {
                pushed = false;
                popEvent.Invoke();
            }
            anim.SetBool("lever_pushed", pushed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pushed = false;
        anim.SetBool("lever_pushed", pushed);
        popEvent.Invoke();
    }
}
