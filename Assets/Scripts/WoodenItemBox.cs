using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WoodenItemBox : MonoBehaviour {

    public KeyCode click;
    public int clicked = 0;

    public UnityEvent pushEvent;
    public UnityEvent popEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(click))
        {
            clicked++;
            
        }

        if(clicked > 4)
        {
            pushEvent.Invoke();
            clicked = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        clicked = 0;
    }
}
