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
    private SoundManager soundManager;
    public AudioClip Shoot;
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
        soundManager = gameObject.GetComponent<SoundManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Dead == true || Rest == true)
        {
            S = sp.sprite.bounds.size;
            boxC.size = S;
        }
        if (Alex.gameObject.name == "ALEX")
        {
            if ((Alex.GetComponent<Player>().Dead == true && FoundPlayer == true))
                FoundPlayer = false;
        }
        else
        {
            if ((Alex.GetComponent<ALEX_2035>().Dead == true && FoundPlayer == true))
                FoundPlayer = false;
        }
        
        if(gameObject.name.Contains("ENEMY ROBOT"))
        {
            EnemyRobot();
        }
        else
        {
            EnemyOne();
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
        if (collision.gameObject.tag == "Player")
        {
            Animator an = Alex.GetComponent<Animator>();
            if (an.GetBool("Jump") == true || an.GetBool("Flip") == true )
            {
                Physics2D.IgnoreCollision(boxC, Alex.GetComponent<BoxCollider2D>(),true);
                Invoke("CollideWithAlex", 1);
            }

        }
        if (collision.gameObject.tag == "PDRONE")
        {
            Physics2D.IgnoreCollision(boxC, collision.gameObject.GetComponent<BoxCollider2D>(), true);
        }
        if (collision.gameObject.tag == "LEFT BOUND" ||collision.gameObject.tag == "RIGHT BOUND")
                sp.flipX = !sp.flipX;

    }
    private void CollideWithAlex()
    {
        Physics2D.IgnoreCollision(boxC, Alex.gameObject.GetComponent<BoxCollider2D>(),false);
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
                if (Alex.gameObject.name.Contains("2035") == false)
                {
                    animator.SetBool("MELEE", false);
                    animator.SetBool("SPRINT", false);
                    animator.SetBool("WALK", false);
                    animator.SetBool("SHOOT", true);
                }
                else
                {
                    if (Alex.GetComponent<Animator>().GetBool("Stand") == true)
                    {
                        animator.SetBool("MELEE", false);
                        animator.SetBool("SPRINT", false);
                        animator.SetBool("WALK", false);
                        animator.SetBool("SHOOT", true);
                    }
                    else
                    {
                        animator.SetBool("MELEE", false);
                        animator.SetBool("SPRINT", true);
                        animator.SetBool("WALK", true);
                        animator.SetBool("SHOOT", false);
                    }
                }
            }
            else
            {
                animator.SetBool("SHOOT", false);
                animator.SetBool("MELEE", false);
                animator.SetBool("WALK", true);
                animator.SetBool("SPRINT", true);

            }
            if (Alex.gameObject.name == "ALEX")
            {
                if (Alex.GetComponent<Player>().Dead == true)
                {
                    animator.SetBool("SHOOT", false);
                    FoundPlayer = false;
                }
            }
            else
            {
                if (Alex.GetComponent<ALEX_2035>().Dead == true)
                {
                    animator.SetBool("SHOOT", false);
                    FoundPlayer = false;
                }
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
        if (Alex.gameObject.name == "ALEX")
        {
            if (FoundPlayer == true && Mathf.Abs(transform.position.x - Alex.transform.position.x) <= 5 && Alex.GetComponent<Player>().Dead == false)
            {
                Alex.GetComponent<Player>().health = 0;
                Alex.GetComponent<Player>().HealthBarUpdate();
                Alex.GetComponent<Animator>().SetBool("Death", true);
                Alex.GetComponent<Player>().BloodEffect.Play("DEATH EFFECT");
                FoundPlayer = false;
            }
        }
        else
        {
            if (FoundPlayer == true && Mathf.Abs(transform.position.x - Alex.transform.position.x) <= 5 && Alex.GetComponent<ALEX_2035>().Dead == false)
            {

                Alex.GetComponent<ALEX_2035>().health = 0;
                Alex.GetComponent<ALEX_2035>().HealthBarUpdate();
                Alex.GetComponent<Animator>().SetBool("Death", true);
                Alex.GetComponent<ALEX_2035>().BloodEffect.Play("DEATH EFFECT");
                FoundPlayer = false;
            }
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
        Destroy(gameObject.GetComponent<AudioSource>());
        Destroy(soundManager);
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
                Alex.GetComponent<ScoreManager>().GunKills++;
                // boxC.size = new Vector2(1, 1);
                Physics2D.IgnoreCollision(boxC, Alex.gameObject.GetComponent<BoxCollider2D>(), true);
                if (gameObject.name.Contains("ENEMY ROBOT") == false) 
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
        soundManager.StopAudio();
        soundManager.PlayOnceSound(Shoot);
        GameObject FiredBullet;

        if (sp.flipX == false)
        {

            FiredBullet = (GameObject)Instantiate(Bullet, new Vector3(gameObject.transform.position.x + 3.5f, gameObject.transform.position.y + 2, 0), Quaternion.identity);
            FiredBullet.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {

            FiredBullet = (GameObject)Instantiate(Bullet, new Vector3(gameObject.transform.position.x - 3.5f, gameObject.transform.position.y + 2, 0), Quaternion.identity);
            FiredBullet.GetComponent<SpriteRenderer>().flipX = true;
        }
        FiredBullet.GetComponent<Bullet>().EnemyMode = true;
        FiredBullet.GetComponent<Bullet>().DroneMode = false;
        FiredBullet.GetComponent<Bullet>().PlayerMode = false;
    }
}
