using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WoodenItemBox : MonoBehaviour {

    public KeyCode click;
    public int clicked = 0;

    public GameObject item_key;

    public bool itemExists = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(click))
            {
                clicked++;
            }
            if (clicked >= 5)
            {
                GameObject player = other.gameObject;
                if (!player.GetComponent<Character>().isthereItem)
                {
                    player.GetComponent<Character>().GetItem(item_key);
                    clicked = 0;
                    itemExists = false;
                } else
                {
                    //item exists
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clicked = 0;
        }
    }
}
