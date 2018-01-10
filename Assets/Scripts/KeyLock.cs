using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{

    public bool key1, key2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key1")
        {
            key1 = true;
            Debug.Log("key1");
        }
        else if (other.name == "Key2")
        {
            key2 = true;
            Debug.Log("key2");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Key1")
        {
            key1 = false;
        }
        else if (other.name == "Key2")
        {
            key2 = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (key1 && key2)
        {
            Debug.Log("Both key");
            //do animation
        }
    }
}