using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

    public Animator anim;

    public UnityEvent collisionEvent;
    public UnityEvent collisionExitEvent;

    public AudioSource clickAudio;
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
        if (SceneManager.GetActiveScene().name.Equals("Scene_road")){
            if (!fence)
            {
                GameObject.Find("fenceCurved").GetComponent<rotate_fence>().return_fence();
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "button_sphere")
        {
            clickAudio.Play();
            Debug.Log("collision");
            state = ButtonState.pushed;
            anim.SetInteger("buttonState", (int)state);
            collisionEvent.Invoke();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player") {
            if (SceneManager.GetActiveScene().name.Equals("Scene_road"))
            {
                GameObject.Find("fenceCurved").GetComponent<rotate_fence>().button_down();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Untagged")
        {
            Debug.Log("bye_collision");
            state = ButtonState.notpushed;
            anim.SetInteger("buttonState", (int)state);
            collisionExitEvent.Invoke();
        }
    }

    public void next_map()
    {
        AsyncOperation async;
        async = SceneManager.LoadSceneAsync("stage2");
    }
}
