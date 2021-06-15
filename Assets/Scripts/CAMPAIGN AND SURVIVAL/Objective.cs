using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    private Text ObjectiveText;
    void Start()
    {
        ObjectiveText = GetComponent<Text>();
        SetObjective();
    }
    void SetObjective()
    {
        string SceneName = SceneManager.GetActiveScene().name;
        if (SceneName.Contains("LEVEL 6")) 
            ObjectiveText.text = "EXECUTE ALEX AND DISARM THE NUKE";
        else if (SceneName.Contains("LEVEL 4"))
            ObjectiveText.text = "ESCAPE FROM THE RADIATION";
        else if (SceneName.Contains("LEVEL 5"))
            ObjectiveText.text = "ELIMINATE THE POLICE FORCE";
        else if (SceneName.Contains("LEVEL"))
            ObjectiveText.text = "ELIMINATE ALL ALEX'S MEN";
        else if (SceneName.Contains("1-")|| SceneName.Contains("2-"))
            ObjectiveText.text = "SURVIVE WAVES OF ENEMIES";
        else if (SceneName.Contains("COOP"))
            ObjectiveText.text = "ELIMINATE ALL ENEMIES AND DISARM THE BOMB";

    }
}
