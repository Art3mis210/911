﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefuseBomb : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D boxC;
    private bool Hacked;
    private void Start()
    {
        boxC = gameObject.GetComponent<BoxCollider2D>();
        Hacked = false;
    }
    private void Update()
    {
        if (Time.timeScale == 0.5f && SceneManager.sceneCount == 1 && Hacked == true)
        {
            Time.timeScale = 1;

            Invoke("NextScene", 5);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && (Input.GetKey(KeyCode.H) || Input.GetKey("joystick button 8")) && Hacked == false)
        {
            Time.timeScale = 0;
            Destroy(boxC);
            SceneManager.LoadScene("HACK", LoadSceneMode.Additive);
            Hacked = true;
        }
    }
    private void NextScene()
    {
        SceneManager.LoadScene("MISSION COMPLETED");
    }
}
