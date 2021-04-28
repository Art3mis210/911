using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Melee_Trigger : MonoBehaviour
{
    public GameObject Alex;
    private Player player;
    void Start()
    {
        player = Alex.GetComponent<Player>();
    }
    void Update()
    {
        if (Alex.GetComponent<SpriteRenderer>().flipX == true)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="ENEMY")
        {
            if (Alex.GetComponent<Animator>().GetBool("Melee")==true && player.MeleeComplete==true && collision.gameObject.GetComponent<Enemy_One>().Dead==false)
            {
                Physics2D.IgnoreCollision(Alex.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
                collision.gameObject.GetComponent<Animator>().SetBool("STABBED", true);
                player.MeleeComplete = false;

            }
        }
    }
}
