using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sound_Detection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyParent;
    private void Update()
    {
        if (EnemyParent.GetComponent<Enemy>().FoundPlayer == true)
            Destroy(gameObject);
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Animator an = collision.gameObject.GetComponent<Animator>();
            if(an.GetBool("Stand")==true && an.GetBool("Move")==true)
            {
                Enemy enemyScript = EnemyParent.gameObject.GetComponent<Enemy>();
                if(enemyScript.StayIdle==false)
                {
                    enemyScript.FoundPlayer = true;
                }
            }
        }
        if(collision.gameObject.tag=="PDRONE" && Input.GetKeyDown(KeyCode.Q) && EnemyParent.GetComponent<Enemy>().FoundPlayer==false)
        {
            EnemyParent.GetComponent<Animator>().SetBool("WALK", false);
            if(collision.gameObject.GetComponent<Transform>().position.x<EnemyParent.gameObject.GetComponent<Transform>().position.x)
            {
                EnemyParent.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                EnemyParent.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
