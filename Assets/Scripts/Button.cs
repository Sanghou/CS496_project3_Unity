using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour {

    public Animator anim;

    public UnityEvent collisionEvent;
    public UnityEvent collisionExitEvent;

    public AudioSource clickAudio;

    public enum ButtonState
    {
        pushed = 0,
        notpushed
    }

    public ButtonState state = ButtonState.notpushed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            clickAudio.Play();
            state = ButtonState.pushed;
            anim.SetInteger("buttonState", (int)state);
            collisionEvent.Invoke();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            state = ButtonState.notpushed;
            anim.SetInteger("buttonState", (int)state);
            collisionExitEvent.Invoke();
        }
    }
}
