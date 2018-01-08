using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_fence : MonoBehaviour {

    [SerializeField]
    private GameObject rotating_fence = null;

    private float rotated = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //mouse_down();
        if (rotated > 0)
        {
            rotated -= Time.deltaTime * 20;
            transform.Rotate(-Vector3.right * Time.deltaTime * 20);
        }
    }


    public void button_down()
    {
        if (rotated < 110)
        {
            Debug.Log("110 under");
            rotated += Time.deltaTime * 40;
            transform.Rotate(Vector3.right * Time.deltaTime * 40);
        }
    }

    public void return_fence()
    {
        
    }
}
