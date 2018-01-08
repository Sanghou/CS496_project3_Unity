using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {

    public GameObject Fire;
    List<GameObject> fireList = new List<GameObject>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BurnWall()
    {
        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                fireList.Add(Instantiate(Fire, new Vector3(0.56f, 2.06f, -2.98f + 1.31f * i), Quaternion.Euler(-90, 0, 0)));
            }
        }
    }

    public void ExtinguishFire()
    {
        while (fireList.Count != 0)
        {
            Destroy(fireList[0]);
            fireList.RemoveAt(0);
        }
    }
}
