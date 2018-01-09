using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoNextStage : MonoBehaviour {

    public bool player1 = false;
    public bool player2 = false;
    public string nextStage;

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player1")
        {
            player1 = true;
            Debug.Log("player1" + player1);
        }
        else if (other.name == "Player2")
        {
            player2 = true;
            Debug.Log("player2" + player2);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Player1")
        {
            player1 = false;
        }
        else if (other.name == "Player2")
        {
            player2 = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (player1 && player2)
        {
            Debug.Log("" + player1 + player2);
            SceneManager.LoadScene(nextStage);
        }
    }
}
