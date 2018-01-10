using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {

    public Vector3 closetheDoor;
    public Vector3 openlittle;
    public GameObject door;
    //public float countdown;
    float timeLeft;
    bool timeOn = false;
    int count = 50;

    public AudioSource openDoor;

    // Use this for initialization
    void Start () {
        timeLeft = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (timeOn)
        {
            count -= 1;
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0f && count!=0)
            {
                open();
            }
        }
        
        
    }

    public void open()
    {
        //Debug.Log(door.transform.position);
        timeOn = true;
        openDoor.Play();
        door.transform.position += openlittle;
        timeLeft = 3f;
    }

    public void close()
    {
        door.transform.position = closetheDoor;
        timeOn = false;
    }
}
