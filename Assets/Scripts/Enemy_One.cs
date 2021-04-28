﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_One : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer sp;
    private Animator animator;
    private BoxCollider2D boxC;
    private Vector2 S;
    public bool FoundPlayer=false;
    private int stopMoving;
    public bool Dead;
    public GameObject Alex;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxC = GetComponent<BoxCollider2D>();
        stopMoving = 0;
        Dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        S = sp.sprite.bounds.size;
        boxC.size = S;
        if (FoundPlayer==true)
        {
            if (transform.position.x - Alex.transform.position.x < 0)
            {
                sp.flipX = true;
            }
            else
                sp.flipX = false;
            if(Mathf.Abs(transform.position.x - Alex.transform.position.x) <= 5)
            {
                animator.SetBool("SHOOT", false);
                animator.SetBool("WALK", false);
                animator.SetBool("SPRINT", false);
                animator.SetBool("MELEE", true);
            }
            else if (Mathf.Abs(transform.position.x-Alex.transform.position.x)<=15)
            {
                animator.SetBool("SPRINT", false);
                animator.SetBool("WALK", false);
                animator.SetBool("SHOOT", true);
            }
            else
            {
                animator.SetBool("SHOOT", false);
                animator.SetBool("MELEE", false);
                animator.SetBool("WALK", true);
                animator.SetBool("SPRINT", true);
                
            }
        }
        else
        {
            animator.SetBool("SHOOT", false);
            animator.SetBool("MELEE", false);
            animator.SetBool("SPRINT", false);
            animator.SetBool("WALK",true);
        }

    }
    public void Move(float speed)
    {
        if (sp.flipX == true)
            transform.Translate(speed * Vector3.right * 0.01f);
        else
            transform.Translate(speed * Vector3.left * 0.01f);
    }
    public void StopMoving()
    {
        if (FoundPlayer == false)
        {
            if (stopMoving == 2)
            {
                animator.SetBool("WALK", false);
                stopMoving = 0;
            }
            else
                stopMoving++;
        }

    }
    public void StartMoving()
    {
        if (FoundPlayer == false)
        {
            animator.SetBool("WALK", true);
        }
    }
    public void TurnAround()
    {
        if (FoundPlayer == false)
            sp.flipX = !sp.flipX;
    }
    public void Died()
    {
        Dead = true;
    }
    public void KillAlex()
    {
        if (FoundPlayer == true)
        {
            Alex.GetComponent<Animator>().SetBool("Death", true);
            FoundPlayer = false;
            gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void TurnColliderOff()
    {
        Destroy(rigidBody);
        Destroy(boxC);
        enabled = false;
    }

    public void StopAnimation(string parameter)
    {
        animator.SetBool(parameter, false);
    }
}
