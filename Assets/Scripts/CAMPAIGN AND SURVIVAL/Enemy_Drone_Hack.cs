using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Drone_Hack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Drone;
    private BoxCollider2D boxC;
    public bool Hacked;
    private void Start()
    {
        boxC = GetComponent<BoxCollider2D>();
        Hacked = false;
    }
    private void Update()
    {
        if(Time.timeScale==0.5f && SceneManager.sceneCount==1 && Hacked==true)
        {
            Drone.GetComponent<EnemyDrone>().Score.Hacks++;
            DestroyDrone();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if((collision.gameObject.tag=="Player"|| collision.gameObject.tag == "PDRONE") && (Input.GetKey(KeyCode.H)|| Input.GetKey("joystick button 3")) && Hacked==false)
        {
            
            Debug.Log("Drone HAcked");
            Time.timeScale = 0;
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), Drone.GetComponent<BoxCollider2D>(), true);
            SceneManager.LoadScene("HACK", LoadSceneMode.Additive);
            boxC.enabled = false;
            Hacked = true;
        }
    }
    private void DestroyDrone()
    {
        Drone.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.None;
        Drone.GetComponent<Animator>().enabled = false;
        Drone.GetComponent<Rigidbody2D>().gravityScale = 1;
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
