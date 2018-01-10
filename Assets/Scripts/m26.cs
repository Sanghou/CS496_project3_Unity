using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m26 : MonoBehaviour {

	// Use this for initialization
	public void pick()
    {
        gameObject.SetActive(false);
    }

    public void use()
    {
        gameObject.SetActive(true);
    }
}
