using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Drone : MonoBehaviour
{
    // Start is called before the first frame update
    private float h;
    private float v;
    private int speed;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;
    public Player player;
    public GameObject Bullet;
    private int Ammo;
    public bool Control;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        speed = 10;
        Ammo = 10;
        Control = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Control==true && SceneManager.sceneCount==1)
            Movement();
    /*    if(player.Dead==true)
        {
            Destroy(gameObject);
        }*/
    }
    private void Movement()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector2(h * speed, v * speed);
        if (Input.GetKeyDown(KeyCode.R))
        {
            sprite.flipX = !sprite.flipX;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            player.enabled = true;
            player.Unfreeze();
            player.Control = true;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Ammo > 0)
        {
            Ammo--;
            Fire();
        }
    }
    public void Fire()
    {
        Bullet.GetComponent<Bullet>().DroneMode = false;
        Bullet.GetComponent<Bullet>().EnemyMode = false;
        Bullet.GetComponent<Bullet>().PlayerMode = true;
        if (sprite.flipX == false)
        {
            Bullet.GetComponent<SpriteRenderer>().flipX = false;
            Instantiate(Bullet, new Vector3(gameObject.transform.position.x + 3.5f, gameObject.transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            Bullet.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(Bullet, new Vector3(gameObject.transform.position.x - 3.5f, gameObject.transform.position.y, 0), Quaternion.identity);
        }
    }
}
