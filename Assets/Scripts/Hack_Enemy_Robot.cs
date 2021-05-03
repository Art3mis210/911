using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hack_Enemy_Robot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Robot;
    private BoxCollider2D boxC;
    private void Start()
    {
        boxC = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (Time.timeScale == 0.1f && GameObject.Find("HACK KEYPAD") == false && boxC.enabled==false)
        {
            TurnOffRobot();
        }
        if (Robot.GetComponent<Enemy>().FoundPlayer == true)
            Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKey(KeyCode.H) && Robot.GetComponent<Enemy>().FoundPlayer == false)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("HACK", LoadSceneMode.Additive);
            boxC.enabled = false;

        }
    }
    private void TurnOffRobot()
    {
        Robot.GetComponent<Animator>().SetBool("STABBED", true);
        enabled = false;
        Time.timeScale = 1;
    }
}
