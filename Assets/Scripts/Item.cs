using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public bool inventory;

    public void DoInteraction()
    {
        gameObject.SetActive(false);
    }

    public void Usenow()
    {
        gameObject.SetActive(true);
    }

}
