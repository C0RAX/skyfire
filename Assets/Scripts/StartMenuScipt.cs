using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenuScipt : MonoBehaviour {

    IEnumerator ChangeLevel1()
    {
        GetComponent<FaderScript>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }

    IEnumerator ChangeLevel2()
    {
        GetComponent<FaderScript>().BeginFade(1);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(2);
    }

    public void StartLevel1()
    {
        StartCoroutine(ChangeLevel1());
     
    }

    public void StartLevel2()
    {
        StartCoroutine(ChangeLevel2());

    }

    public void ExitGame()
    {
        Debug.Log("quitting");
        Application.Quit();
    }


}
