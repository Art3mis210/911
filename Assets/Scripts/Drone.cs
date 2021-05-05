using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    // Start is called before the first frame update
    private float h;
    private float v;
    private int speed;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    public Player player;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector2(h * speed, v *  speed);
        if(Input.GetKeyDown(KeyCode.R))
        {
            sprite.flipX = !sprite.flipX;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.enabled = true;
            player.Unfreeze();
            player.DroneMode = false;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Destroy(gameObject);
        }
    }
}
