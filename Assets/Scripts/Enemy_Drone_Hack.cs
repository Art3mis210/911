using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Drone_Hack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Drone;
    private BoxCollider2D boxC;
    private void Start()
    {
        boxC = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if(Time.timeScale==0.1f && GameObject.Find("HACK KEYPAD")==false)
        {
            DestroyDrone();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player" && Input.GetKey(KeyCode.H))
        {
            Time.timeScale = 0;
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), Drone.GetComponent<BoxCollider2D>(), true);
            SceneManager.LoadScene("HACK", LoadSceneMode.Additive);
            boxC.enabled = false;
            
        }
    }
    private void DestroyDrone()
    {
        Drone.GetComponent<Animator>().enabled = false;
        Drone.GetComponent<Rigidbody2D>().gravityScale = 1;
        Time.timeScale = 1;
        Destroy(Drone.transform.GetChild(0).gameObject);
        Destroy(Drone.transform.GetChild(1).gameObject);

    }
}
