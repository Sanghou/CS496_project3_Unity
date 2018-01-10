using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {

    public AudioSource Audio;

    public GameObject Fire;
    List<GameObject> fireList = new List<GameObject>();

    float timeLeft, nextTime;
    bool timerOn = false;

    GameObject treeWall;

    bool alive = true;

    // Use this for initialization
    void Start () {
        resetTimer();
        treeWall = GameObject.Find("TreeWall");
    }

    // Update is called once per frame
    void Update() {
        if (timerOn)
        {
            timeLeft -= Time.deltaTime;
            //Debug.Log("Time left: " + timeLeft);

            if (timeLeft < 0)
            {
                treeWall.SetActive(false);
                StartCoroutine(FadeOut(Audio, 5f));
                while (fireList.Count != 0)
                {
                    Destroy(fireList[0]);
                    fireList.RemoveAt(0);
                }
                alive = false;
                //Debug.Log("Time Over!");
                return;
            }

            if (timeLeft < nextTime)
            {
                nextTime -= 1f;
                for (int i = 0; i < 12; i++)
                {
                    fireList.Add(Instantiate(Fire, new Vector3(0.56f, 2.06f, -2.98f + 1.31f * i), Quaternion.Euler(-90, 0, 0)));
                }
            }
        }
	}

    private void resetTimer()
    {
        timerOn = false;
        timeLeft = 5f;
        nextTime = 4f;
    }

    public void BurnWall()
    {
        if (!alive)
        {
            return;
        }

        Audio.Play();
        timerOn = true;
        for (int i = 0; i < 12; i++)
        {
            fireList.Add(Instantiate(Fire, new Vector3(0.56f, 2.06f, -2.98f + 1.31f * i), Quaternion.Euler(-90, 0, 0)));
        }
    }

    public void ExtinguishFire()
    {
        resetTimer();
        Audio.Stop();
        while (fireList.Count != 0)
        {
            Destroy(fireList[0]);
            fireList.RemoveAt(0);
        }
    }

    public static IEnumerator FadeOut (AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while(audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
