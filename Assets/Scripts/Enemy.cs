using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
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
    public bool StayIdle;
    public int WalkArea;
    public bool Rest;
    public int health;
    public GameObject Bullet;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxC = GetComponent<BoxCollider2D>();
        stopMoving = 0;
        Dead = false;
        if (gameObject.name == "ENEMY HAZARD UNIT")
            Rest = false;
    }

    // Update is called once per frame
    void Update()
    {
        S = sp.sprite.bounds.size;
        boxC.size = S;
        if(gameObject.name=="ENEMY 1" || gameObject.name == "ENEMY HAZARD UNIT")
        {
            EnemyOne();
        }
        else if(gameObject.name=="ENEMY ROBOT")
        {
            EnemyRobot();
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ENEMY")
        {
            if(collision.gameObject.GetComponent<Enemy>().Dead==true)
            {
                FoundPlayer = true;
            }
            Physics2D.IgnoreCollision(boxC, collision.gameObject.GetComponent<BoxCollider2D>(), true);
        }
    }
    private void EnemyOne()
    {
        if (FoundPlayer == true && StayIdle == false)
        {
            
            if (transform.position.x - Alex.transform.position.x < 0)
            {
                sp.flipX = false;
            }
            else
                sp.flipX = true;
            if (Mathf.Abs(transform.position.x - Alex.transform.position.x) <= 5)
            {
                animator.SetBool("MELEE", true);
                animator.SetBool("SHOOT", false);
                animator.SetBool("WALK", false);
                animator.SetBool("SPRINT", false);

            }
            else if (Mathf.Abs(transform.position.x - Alex.transform.position.x) <= 15)
            {
                animator.SetBool("MELEE", false);
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
            if (Alex.GetComponent<Player>().Dead == true)
            {
                animator.SetBool("SHOOT", false);
                FoundPlayer = false;
            }
        }
        else
        {
            animator.SetBool("SHOOT", false);
            animator.SetBool("MELEE", false);
            animator.SetBool("SPRINT", false);
        }
    }
    private void EnemyRobot()
    {
        if (FoundPlayer == true && StayIdle == false)
        {
            if (transform.position.x - Alex.transform.position.x < 0)
            {
                sp.flipX = false;
            }
            else
                sp.flipX = true;
            if (Mathf.Abs(transform.position.x - Alex.transform.position.x) <= 5)
            {
                animator.SetBool("MELEE", true);
                animator.SetBool("WALK", false);
                animator.SetBool("SPRINT", false);

            }
            else
            {
                animator.SetBool("MELEE", false);
                animator.SetBool("WALK", true);
                animator.SetBool("SPRINT", true);

            }
        }
        else
        {
            animator.SetBool("MELEE", false);
            animator.SetBool("SPRINT", false);
        }
    }
    public void Move(float speed)
    {
        if (sp.flipX == true)
            transform.Translate(speed * Vector3.left * 0.01f);
        else
            transform.Translate(speed * Vector3.right * 0.01f);
    }
    public void StopMoving()
    {
        if (FoundPlayer == false)
        {
            if (stopMoving == WalkArea)
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
        if (FoundPlayer == false && StayIdle==false)
        {
            animator.SetBool("WALK", true);
        }
        
    }
    public void TurnAround()
    {
        if (FoundPlayer == false && StayIdle == false)
            sp.flipX = !sp.flipX;
    }
    public void Died()
    {
        Dead = true;
    }
    public void KillAlex()
    {
        if (FoundPlayer == true && Mathf.Abs(transform.position.x - Alex.transform.position.x) <= 5)
        {
            
            Alex.GetComponent<Animator>().SetBool("Death", true);
            FoundPlayer = false;
            gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void TurnColliderOff()
    {
        if(transform.childCount>=1)  
            Destroy(gameObject.transform.GetChild(0).gameObject);
        if(transform.childCount == 1)
            Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(rigidBody);
        Destroy(boxC);
        gameObject.GetComponent<Enemy>().enabled = false;
        
    }
    public void StopAnimation(string parameter)
    {
        animator.SetBool(parameter, false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="BULLET")
        {
            Destroy(collision.gameObject);
            if(collision.gameObject.GetComponent<Bullet>().EnemyMode==false && collision.gameObject.GetComponent<Bullet>().DroneMode == false)
                health-=2;
            if (health <= 0 && Dead==false)
            {
                // boxC.size = new Vector2(1, 1);
                Physics2D.IgnoreCollision(boxC, Alex.gameObject.GetComponent<BoxCollider2D>(), true);
                if (gameObject.name!="ENEMY ROBOT")
                    animator.SetBool("DEATH", true);
                else
                {
                        animator.SetBool("STABBED", true);
                }
                Dead = true;
               // enabled = false;
            }
            else
            {
                FoundPlayer = true;
            }
        }
    }
    public void Fire()
    {
        Bullet.GetComponent<Bullet>().EnemyMode = true;
        Bullet.GetComponent<Bullet>().DroneMode = false;
        Bullet.GetComponent<Bullet>().PlayerMode = false;
        if (sp.flipX == false)
        {
            Bullet.GetComponent<SpriteRenderer>().flipX = false;
            Instantiate(Bullet, new Vector3(gameObject.transform.position.x + 3.5f, gameObject.transform.position.y + 2, 0), Quaternion.identity);
        }
        else
        {
            Bullet.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(Bullet, new Vector3(gameObject.transform.position.x - 3.5f, gameObject.transform.position.y + 2, 0), Quaternion.identity);
        }
    }
}
