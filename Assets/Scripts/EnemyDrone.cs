using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrone : MonoBehaviour
{
    private BoxCollider2D boxC;
    private Rigidbody2D rigidBody2D;
    public int health;
    public bool destroyed;
    private void Start()
    {
        boxC = gameObject.GetComponent<BoxCollider2D>();
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        health = 5;
        destroyed = false;
    }
    private void Update()
    {
        if(health<=0 && destroyed==false)
        {
            DestroyDrone();
            destroyed = true;
        }
    }
    public void DestroyDrone()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.None;
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 10;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="GROUND")
        {
            rigidBody2D.gravityScale = 0;
            boxC.enabled = false;
            enabled = false;

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BULLET")
        {
            health--;
            Destroy(collision.gameObject);
        }
    
    }

}
