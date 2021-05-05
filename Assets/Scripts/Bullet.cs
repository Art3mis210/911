using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer sp;
    private int speedX;
    private int speedY;
    public bool DroneMode;
    public bool EnemyMode;
    public bool PlayerMode;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        if(DroneMode==true)
        {
            transform.rotation= Quaternion.Euler(0, 0, 90);
            speedX = 0;
            speedY = -100;
        }
        if(EnemyMode==true || PlayerMode==true)
        {
            if (sp.flipX == false)
            {
                speedX = 100;
                speedY = 0;
            }
            else
            {
                speedX = -100;
                speedY = 0;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(speedX, speedY);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GROUND")
        {
            Destroy(gameObject);
        }
    }
    /*   private void OnTriggerEnter2D(Collider2D collision)
       {

           if (collision.gameObject.tag == "Player")
           {
               collision.gameObject.GetComponent<Player>().health--;
               Destroy(gameObject);
           }
           else if (collision.gameObject.tag == "Enemy")
           {
               collision.gameObject.GetComponent<Enemy>().health--;
               Destroy(gameObject);
           }
       } */
}
