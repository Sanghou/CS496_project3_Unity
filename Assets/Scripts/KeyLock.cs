using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : MonoBehaviour
{

    public GameObject key1, key2;
    public GameObject Cliff;

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
            key1 = other.gameObject;
            Debug.Log("key1");
        }
        else if (other.name == "Key2")
        {
            key2 = other.gameObject;
            Debug.Log("key2");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Key1")
        {
            key1 = null;
        }
        else if (other.name == "Key2")
        {
            key2 = null;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (key1 != null && key2 != null)
        {
            Debug.Log("Both key");
            //do animation
            key1.SetActive(false);
            key2.SetActive(false);
            Cliff.GetComponent<Animator>().SetBool("Cliff On", true);
        }
    }
}