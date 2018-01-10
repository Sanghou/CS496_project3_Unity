using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[1];
    public Image[] items = new Image[1];

	public void AddItem(GameObject item)
    {
        if (inventory[0] == null)
        {
            inventory[0] = item;
            items[0].overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
            Debug.Log(item.name + "was added");
        }
        else
        {
            Debug.Log("inventory Full");
        }
    }

    public void UseItem(GameObject item)
    {
        inventory[0] = null;
        items[0].overrideSprite = null;
    }
}
