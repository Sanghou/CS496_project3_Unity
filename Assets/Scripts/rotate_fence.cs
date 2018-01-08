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

        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (rotated < 110)
            {
                transform.Rotate(Vector3.right * Time.deltaTime * 20);
                rotated += Time.deltaTime * 20;
            }
        }

        else { 
            if(rotated > 0)
            {
                transform.Rotate(- Vector3.right * Time.deltaTime * 20);
                rotated -= Time.deltaTime * 20;
            }
        }
    }
}
