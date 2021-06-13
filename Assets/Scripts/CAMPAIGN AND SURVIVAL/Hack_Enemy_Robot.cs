using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hack_Enemy_Robot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Robot;
    private BoxCollider2D boxC;
    private bool Hacked ;
    private void Start()
    {
        boxC = GetComponent<BoxCollider2D>();
        Hacked = false;
    }
    private void Update()
    {
        if (Robot.GetComponent<Enemy>().FoundPlayer == true || Robot.GetComponent<Enemy>().Dead == true)
            Destroy(gameObject);
        if (Time.timeScale == 0.5 && Hacked==true &&  SceneManager.sceneCount == 1)
        {
            Robot.GetComponent<Enemy>().Alex.GetComponent<ScoreManager>().Hacks++;
            TurnOffRobot();
            
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "PDRONE") && Input.GetKey(KeyCode.H) && Robot.GetComponent<Enemy>().FoundPlayer == false && Hacked==false)
        {

            Time.timeScale = 0;
            SceneManager.LoadScene("HACK", LoadSceneMode.Additive);
            Hacked=true;
            
        }
    }
    private void TurnOffRobot()
    {
        Robot.gameObject.GetComponent<Animator>().SetBool("STABBED", true);
        Time.timeScale = 1;
        Destroy(gameObject);
       // Debug.Log("ABC");
       // enabled = false;
        
    }
}
