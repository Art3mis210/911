using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Survival_Buttons : MonoBehaviour
{
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
        SceneManager.LoadScene(PlayerNo + "-" + LevelNo);
    }
}
