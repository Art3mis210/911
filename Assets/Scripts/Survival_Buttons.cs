using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Survival_Buttons : MonoBehaviour
{
    public GameObject Loading;
    public GameObject LevelButton;
    public GameObject PlayerButton;
    private int LevelNo;
    private int PlayerNo;
    public void OnLevelButtonClick(int i)
    {
        LevelNo = i;
        LevelButton.SetActive(false);
        PlayerButton.SetActive(true);
    }
    public void OnPlayerButtonClick(int i)
    {
        PlayerNo = i;
        StartCoroutine(LoadYourAsyncScene(PlayerNo + "-" + LevelNo));
    }
    IEnumerator LoadYourAsyncScene(string SceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (asyncLoad.progress < 1)
        {
            Loading.SetActive(true);
            yield return new WaitForEndOfFrame();
        }
    }
}
