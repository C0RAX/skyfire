using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject UI;
    public GameObject turrets;
    public GameObject player;

    IEnumerator ChangeLevel0()
    {
        //GameObject a = GameObject.Find("GameController");
        GetComponent<FaderScript>().BeginFade(2);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(0);
    }

    IEnumerator ChangeLevel2()
    {
        //GameObject a = GameObject.Find("GameController");
        GetComponent<FaderScript>().BeginFade(2);
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        if (turrets.transform.childCount == 0)
        {
            if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                StartCoroutine(ChangeLevel2());
            }

            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                StartCoroutine(ChangeLevel0());
            }

        }

        if (player == null) { StartCoroutine(ChangeLevel0()); }
    }


    public void TogglePauseMenu()
    {
        // not the optimal way but for the sake of readability
        if (UI.GetComponentInChildren<Canvas>().enabled)
        {
            UI.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            UI.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0f;
        }

        Debug.Log("GAMEMANAGER:: TimeScale: " + Time.timeScale);
    }

    public void Death()
    {
        StartCoroutine(ChangeLevel0());
    }
}
