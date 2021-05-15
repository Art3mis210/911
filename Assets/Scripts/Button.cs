using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void OnButtonClick(string SceneName)
    {
        Time.timeScale = 1;
        if (SceneName == "EXIT")
            Application.Quit();
        else if(SceneName=="RESUME")
        {
            SceneManager.UnloadSceneAsync("PAUSED");
        }
        else if (SceneName == "RESTART")
        {
            SceneManager.UnloadSceneAsync("GAME OVER");
        }
        else
            SceneManager.LoadScene(SceneName);
    }
}
