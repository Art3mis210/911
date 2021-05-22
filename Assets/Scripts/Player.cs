using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sp;
    private Animator animator;
    public GameObject Drone;
    public GameObject Camera;
    public bool MeleeComplete;
    private BoxCollider2D boxC;
    public bool Dead;
    public int health;
    public GameObject Bullet;
    public bool Control;
    public Animator BloodEffect;
    public bool WalkMode;
    public GameObject HealthBar;
    private int Ammo;
    public Text AmmoIndicator;
    private bool Paused;
    private bool GameOver;
    private PlayerSoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Dead = false;
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        MeleeComplete = false;
        boxC = GetComponent<BoxCollider2D>();
        Control = true;
        Ammo = 85;
        AmmoIndicator.text=Ammo.ToString()+ "/0";
        Paused = false;
        GameOver = false;
        soundManager = gameObject.GetComponent<PlayerSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Camera.transform.position = new Vector3(gameObject.transform.position.x + 5, Camera.transform.position.y, Camera.transform.position.z);
        if(Control == true && Dead == false && SceneManager.sceneCount == 1)
            Movement();
        Vector2 S = sp.sprite.bounds.size;
        boxC.size = S;
        if (Input.GetKey(KeyCode.Escape) && Paused == false)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("PAUSED", LoadSceneMode.Additive);
            Paused = true;
            Camera.GetComponent<Camera>().enabled = (false);

        }
        if (Paused == true && Time.timeScale == 1)
        {
            Camera.GetComponent<Camera>().enabled = (true);
            Paused = false;
        }
        if (Control == true && Camera.activeInHierarchy == false)
            Camera.SetActive(true);
        if(Dead==true && GameOver==false)
        {
            Invoke("LoadGameOverScene", 5);
            GameOver = true;
        }

    }
    private void Movement()
    {

        if (WalkMode == false)
        {
            if (animator.GetBool("Pistol") == false && animator.GetBool("Stand") == true && animator.GetBool("Flip") == false)
            {
                if (Input.GetKey(KeyCode.B))
                {
                    animator.SetBool("Flip", true);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                sp.flipX = false;
                animator.SetBool("Move", true);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                sp.flipX = true;
                animator.SetBool("Move", true);
            }
            else
            {
                //  Move(0);
                animator.SetBool("Move", false);
                animator.SetBool("Sprint", false);

            }
            if ((Input.GetKeyDown(KeyCode.LeftControl)))
            {
                animator.SetBool("Stand", !animator.GetBool("Stand"));

            }
            if ((Input.GetKey(KeyCode.LeftShift)) && animator.GetBool("Move") == true)
            {
                
                animator.SetBool("Sprint", true);

            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (animator.GetBool("Pistol") == false)
                    animator.SetBool("Pistol", true);
                else
                    animator.SetBool("Pistol", false);
            }
            if (animator.GetBool("Jump") == false && animator.GetBool("Stand") == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("Jump", true);
                }
            }
            if (animator.GetBool("Pistol") == true)
            {
                if (Input.GetMouseButton(0))
                {
                    animator.SetBool("Shoot", true);
                }
                else
                    animator.SetBool("Shoot", false);
            }
            if (animator.GetBool("Pistol") == true || animator.GetBool("Move") == false)
            {
                if (Input.GetMouseButton(1))
                {
                    animator.SetBool("Melee", true);
                }
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                var drone = Instantiate(Drone, new Vector2(transform.position.x + 1, transform.position.y + 2), Quaternion.identity);
                drone.GetComponent<Drone>().player = this;
                animator.SetBool("Sprint", false);
                animator.SetBool("Move", false);
                Control = false;
                Camera.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.N))
            {
                Camera.GetComponent<DeferredNightVisionEffect>().enabled = !Camera.GetComponent<DeferredNightVisionEffect>().enabled;
            }
        }
        else if(WalkMode==true)
        {   if (Input.GetKey(KeyCode.D))
            {
                sp.flipX = false;
                animator.SetBool("Move", true);

            }
            else
            {
                //  Move(0);
                animator.SetBool("Move", false);
                animator.SetBool("Sprint", false);

            }
        }
        
    }
    public void SetMeleeComplete()
    {
        MeleeComplete = true;
    }
    public void TurnColliderOff()
    {
        Destroy(rigidBody);
        Destroy(boxC);
        enabled = false;
    }
    public void Move(float speed)
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (sp.flipX == true)
                transform.Translate(speed * Vector3.left * 0.01f);
            else
                transform.Translate(speed * Vector3.right * 0.01f);
        }


    }
    public void HealthBarUpdate()
    {
        for (int child = 0; child <= 7; child++)
        {
            HealthBar.transform.GetChild(child).gameObject.SetActive(health >= child+1);
        }
      //  HealthBar.transform.GetChild(1).gameObject.SetActive(health >= 2);
      //  HealthBar.transform.GetChild(2).gameObject.SetActive(health >= 3);
    }
    public void Unfreeze()
    {
        rigidBody.constraints = RigidbodyConstraints2D.None;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    public void Freeze()
    {
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void StopAnimation(string parameter)
    {
        animator.SetBool(parameter, false);
    }
    public void Jump(float speed)
    {
        transform.Translate(speed * Vector3.up * 0.01f);
    }

    public void JumpMove(float speed)
    {
        if (sp.flipX == true)
            transform.Translate(speed * Vector3.left * 0.01f);
        else
            transform.Translate(speed * Vector3.right * 0.01f);
    }
    public void TurnScriptOff()
    {
        enabled = false;
    }
    public void SetDeadTrue()
    {
        Dead = true;
    }
    public void Fire()
    {
        if (Ammo > 0)
        {
            soundManager.StopAudio();
            soundManager.PlayOnceSound(soundManager.Shoot);
            Bullet.GetComponent<Bullet>().DroneMode = false;
            Bullet.GetComponent<Bullet>().EnemyMode = false;
            Bullet.GetComponent<Bullet>().PlayerMode = true;
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
            Ammo--;
            AmmoIndicator.text = Ammo.ToString()+"/0";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BULLET")
        {
            Destroy(collision.gameObject);
            health -= 1;
            HealthBarUpdate();
            if (health <= 0 && Dead==false)
            {
                animator.SetBool("Death", true);
                BloodEffect.Play("DEATH EFFECT");
                Dead = true;
            }
            else
            {
                BloodEffect.Play("BLOOD EFFECT");
            }
        }
    }
    private void LoadGameOverScene()
    {
        Camera.GetComponent<Camera>().enabled = false;
        SceneManager.LoadScene("GAME OVER", LoadSceneMode.Additive);
    }



}