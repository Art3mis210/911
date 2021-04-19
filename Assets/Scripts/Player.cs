using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    private float h;
    private Rigidbody2D rigidBody;
    private SpriteRenderer sp;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*  h = Input.GetAxis("Horizontal");

          if (h != 0)
              sp.flipX = h < 0;
          rigidBody.velocity = new Vector2(h*speed, rigidBody.velocity.y);*/
        Movement();

        Vector2 S = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size;
        gameObject.GetComponent<BoxCollider2D>().size = S;
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2((S.x / 2), 0);
    }
    private void Movement()
    {
        if (animator.GetBool("Jump") == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
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
        if(Input.GetKey(KeyCode.Alpha1))
        {
            if (animator.GetBool("Pistol")==false)
                animator.SetBool("Pistol", true);
            else
                animator.SetBool("Pistol", false);
        }
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

        // transform.position = new Vector3(transform.position.x + (speed*h), transform.position.y, transform.position.z);
        //rigidBody.velocity = new Vector2((speed * h), 0);
        // rigidBody.velocity=(new Vector2(10*speed * h, 0));

    }
    public void StopJump()
    {
        animator.SetBool("Jump", false);
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
}