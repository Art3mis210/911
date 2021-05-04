using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hack_Enemy_Robot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Robot;
    private BoxCollider2D boxC;
    private int limit;
    private void Start()
    {
        boxC = GetComponent<BoxCollider2D>();
        limit = 0;
    }
    private void Update()
    {
        if (Robot.GetComponent<Enemy>().FoundPlayer == true)
            Destroy(gameObject);
        else
        {
            if (Time.timeScale == 0.1f && limit==1 && GameObject.Find("KEYPAD HACK")==false)
            {
                TurnOffRobot();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.H) && Robot.GetComponent<Enemy>().FoundPlayer == false && limit==0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("HACK", LoadSceneMode.Additive);
            limit++;
        }
    }
    private void TurnOffRobot()
    {
        Robot.GetComponent<Animator>().SetBool("STABBED", true);
        Time.timeScale = 1;
        Destroy(gameObject);
        Debug.Log("ABC");
        enabled = false;
        
    }
}
