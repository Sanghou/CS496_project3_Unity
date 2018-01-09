using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour {

    public Animator anim;

    public UnityEvent collisionEvent;
    public UnityEvent collisionExitEvent;

    private float rotated = 0;




    public enum ButtonState
    {
        pushed = 0,
        notpushed
    }

    private bool fence = false;

    public ButtonState state = ButtonState.notpushed;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!fence)
        {
            GameObject.Find("fenceCurved").GetComponent<rotate_fence>().return_fence();
     
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Button_next_map")
        {

        }

        else if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "button_sphere")
        {
            Debug.Log("collision");
            state = ButtonState.pushed;
            anim.SetInteger("buttonState", (int)state);
            collisionEvent.Invoke();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2") {
            GameObject.Find("fenceCurved").GetComponent<rotate_fence>().button_down();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Debug.Log("bye_collision");
            state = ButtonState.notpushed;
            anim.SetInteger("buttonState", (int)state);
            collisionExitEvent.Invoke();
        }
    }
}
