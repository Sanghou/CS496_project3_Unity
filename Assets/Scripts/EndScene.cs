using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour {

	public void RestartBtn()
    {
        SceneManager.LoadScene("Scene_road");
    }

    public void QuitBtn()
    {
        Debug.Log("Quit pressed");
        Application.Quit();
    }
}
