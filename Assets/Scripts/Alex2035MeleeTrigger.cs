﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alex2035MeleeTrigger : MonoBehaviour
{
    public GameObject Alex;
    private ALEX_2035 player;
    public SoundManager soundManager;
    public AudioClip Knockout;

    void Start()
    {
        player = Alex.GetComponent<ALEX_2035>();
    }
    void Update()
    {
        if (Alex.GetComponent<SpriteRenderer>().flipX == true)
            transform.position = new Vector2(Alex.transform.position.x - 1, Alex.transform.position.y + 0.5f);
        else
            transform.position = new Vector2(Alex.transform.position.x + 1, Alex.transform.position.y + 0.5f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("ENEMY HAZARD UNIT"))
        {

            if (Alex.GetComponent<Animator>().GetBool("Melee") == true && player.MeleeComplete == true && collision.gameObject.GetComponent<Enemy>().Dead == false && collision.gameObject.GetComponent<Enemy>().Rest == false)
            {
                soundManager.PlayOnceSound(Knockout);
                Physics2D.IgnoreCollision(Alex.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
                collision.gameObject.GetComponent<Animator>().SetBool("STABBED", true);
                player.MeleeComplete = false;
                collision.gameObject.GetComponent<Enemy>().Rest = true;
                Destroy(collision.gameObject.transform.GetChild(0).gameObject);
                Destroy(collision.gameObject.transform.GetChild(1).gameObject);


            }
            else if (Alex.GetComponent<Animator>().GetBool("Melee") == true && player.MeleeComplete == true && collision.gameObject.GetComponent<Enemy>().Dead == false && collision.gameObject.GetComponent<Enemy>().Rest == true)
            {
                soundManager.PlayOnceSound(Knockout);
                collision.gameObject.GetComponent<Animator>().SetBool("DEATH", true);
                collision.gameObject.GetComponent<Enemy>().Dead = true;
                player.MeleeComplete = false;
                Alex.GetComponent<ScoreManager>().MeleeKills++;
            }
        }
        else if (collision.gameObject.tag == "ENEMY" && collision.gameObject.name.Contains("ENEMY HAZARD UNIT") == false)
        {
            if (Alex.GetComponent<Animator>().GetBool("Melee") == true && player.MeleeComplete == true && collision.gameObject.GetComponent<Enemy>().Dead == false)
            {
                soundManager.PlayOnceSound(Knockout);
                Physics2D.IgnoreCollision(Alex.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
                collision.gameObject.GetComponent<Animator>().SetBool("STABBED", true);
                player.MeleeComplete = false;
                Alex.GetComponent<ScoreManager>().MeleeKills++;

            }
        }
    }
}
