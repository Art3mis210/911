using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Button : MonoBehaviour
{
    public GameObject Loading;
    public void OnButtonClick(string SceneName)
    {
        Time.timeScale = 1;
        if (SceneName == "EXIT")
            Application.Quit();
        else if (SceneName == "RESUME")
        {
            SceneManager.UnloadSceneAsync("PAUSED");
        }
        else if (SceneName == "RESTART")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (SceneName == "NEXT LEVEL")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else if(SceneName.Contains("LEVEL")|| SceneName.Contains("-"))
        {

            Loading.SetActive(true);
            StartCoroutine(LoadYourAsyncScene(SceneName));

        }
        else 
        {
            SceneManager.LoadScene(SceneName);
        }

    }
    IEnumerator LoadYourAsyncScene(string SceneName)
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (asyncLoad.progress<1)
        {
            Loading.SetActive(true);
            yield return new WaitForEndOfFrame();
        }
    }
}

