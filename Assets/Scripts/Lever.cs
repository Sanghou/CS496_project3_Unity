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
        pushEvent.Invoke();
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
            pushEvent.Invoke();
        } else
        {
            pushed = false;
            popEvent.Invoke();
        }
        anim.SetBool("lever_pushed", pushed);
    }

    private void OnTriggerExit(Collider other)
    {
        pushed = false;
        anim.SetBool("lever_pushed", pushed);
        popEvent.Invoke();
    }
}
