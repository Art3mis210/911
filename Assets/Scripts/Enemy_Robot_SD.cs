using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Robot_SD : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    private void Update()
    {
        if (Enemy.GetComponent<SpriteRenderer>().flipX == true)
            transform.position = new Vector2(Enemy.transform.position.x + 8, Enemy.transform.position.y + 1);
        else
            transform.position = new Vector2(Enemy.transform.position.x - 8, Enemy.transform.position.y + 1);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Animator an = collision.gameObject.GetComponent<Animator>();
            if (an.GetBool("Stand") == true && an.GetBool("Move") == true)
            {
                Enemy_Robot EnemyScript = Enemy.GetComponent<Enemy_Robot>();
                //    if(EnemyScript.StayIdle==false)
                {
                    EnemyScript.FoundPlayer = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}

