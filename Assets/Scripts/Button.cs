using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Animator anim;

    public GameObject Fire;

    List<GameObject> fireList = new List<GameObject>();

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
            state = ButtonState.pushed;
            anim.SetInteger("buttonState", (int)state);
            BurnWall();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            state = ButtonState.notpushed;
            anim.SetInteger("buttonState", (int)state);
            ExtinguishFire();
        }
    }

    void BurnWall()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                fireList.Add(Instantiate(Fire, new Vector3(0.56f, 2.06f, -2.98f + 1.31f * i), Quaternion.Euler(-90, 0, 0)));
            }
        }
    }

    void ExtinguishFire()
    {
        while(fireList.Count != 0)
        {
            Destroy(fireList[0]);
            fireList.RemoveAt(0);
        }
    }

}
