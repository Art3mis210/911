using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody2D;
    private SpriteRenderer sp;
    private int speed;
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        if (sp.flipX == false)
            speed = 100;
        else
            speed = -100;

    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(speed, 0);
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
