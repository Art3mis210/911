using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hack : MonoBehaviour
{
    // Start is called before the first frame update
    private string entered_password;
    private string orignal_password;
    public Text Entered_password;
    public Text Check_password;
    public Text Orignal_password;
    void Start()
    {
        orignal_password = Random.Range(1000, 9999).ToString();
        entered_password = "";
        Orignal_password.text = orignal_password;


    }

    // Update is called once per frame
    void Update()
    {
        Entered_password.text = entered_password;
    }
    public void AddDigit(string Digit)
    {
            entered_password += Digit;
    }
    public void Clear()
    {
        entered_password = "";
    }
    public void CheckPassword()
    {
        if (orignal_password == entered_password)
        {
            Check_password.text = "  Success";
            SceneManager.UnloadSceneAsync("HACK");
            Time.timeScale = 0.1f;
        }
        else
            Check_password.text = "Incorrect";
    }
}
