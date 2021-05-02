using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sound_Detection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyParent;
    private void Update()
    {
        if (EnemyParent.GetComponent<SpriteRenderer>().flipX == true)
            transform.position = new Vector2(EnemyParent.transform.position.x + 8, EnemyParent.transform.position.y + 1);
        else
            transform.position = new Vector2(EnemyParent.transform.position.x - 8, EnemyParent.transform.position.y + 1);
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
    }
}
