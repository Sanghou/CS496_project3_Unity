using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("quit");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Ending");
        }
    }

}
