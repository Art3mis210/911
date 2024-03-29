﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private bool Paused;
    private int Battery;
    public GameObject BatteryIndicator;
    public AudioClip Shoot;
    public AudioClip Empty;
    private SoundManager soundManager;
    private int StartInterval;
    private int LastInterval;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        speed = 10;
        Ammo = 5;
        Control = true;
        Paused = false;
        Battery = 0;
        soundManager = gameObject.GetComponent<SoundManager>();
        StartInterval = (int)Time.realtimeSinceStartup;
        LastInterval = (int)Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(Control==true && SceneManager.sceneCount==1 && Time.timeScale==1)
            Movement();
        else if(player.Dead==true)
        {
            Destroy(gameObject);
        }
        if ((Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.JoystickButton7)) && Paused == false)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("PAUSED", LoadSceneMode.Additive);
            Paused = true;
            transform.GetChild(0).gameObject.GetComponent<Camera>().enabled=(false);

        }
        if (Paused == true && Time.timeScale == 1)
        {
            transform.GetChild(0).gameObject.GetComponent<Camera>().enabled = true;
            Paused = false;
        }
        if (Battery < 55)
        {
            LastInterval = (int)Time.realtimeSinceStartup;
            Battery = LastInterval - StartInterval;
            if (Battery > 30)
                BatteryIndicator.SetActive(true);
            Debug.Log(Battery);
        }
        else
            ReturnDrone();
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
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            sprite.flipX = !sprite.flipX;
        }
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetAxis("Drone") < 0)
        {
            player.enabled = true;
            player.Unfreeze();
            player.Control = true;
            rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) ||  Input.GetAxis("SHOOT") != 0 )
        {
            Ammo--;
            Fire();
        }
    }
    public void Fire()
    {
        if (Ammo > 0)
        {
            soundManager.PlayOnceSound(Shoot);
            GameObject FiredBullet;
            if (sprite.flipX == false)
            {

                FiredBullet = (GameObject)Instantiate(Bullet, new Vector3(gameObject.transform.position.x + 3.5f, gameObject.transform.position.y, 0), Quaternion.identity);
                FiredBullet.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {

                FiredBullet = (GameObject)Instantiate(Bullet, new Vector3(gameObject.transform.position.x - 3.5f, gameObject.transform.position.y, 0), Quaternion.identity);
                FiredBullet.GetComponent<SpriteRenderer>().flipX = true;
            }
            FiredBullet.GetComponent<Bullet>().DroneMode = false;
            FiredBullet.GetComponent<Bullet>().EnemyMode = false;
            FiredBullet.GetComponent<Bullet>().PlayerMode = true;
        }
        else
        {
            soundManager.PlayOnceSound(Empty);
        }
    }
    private void ReturnDrone()
    {
        player.enabled = true;
        player.Unfreeze();
        player.Control = true;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        Destroy(gameObject);
    }
}
