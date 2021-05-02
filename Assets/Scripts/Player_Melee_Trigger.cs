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
            transform.position = new Vector2(Alex.transform.position.x - 1, Alex.transform.position.y + 0.5f);
        else
            transform.position = new Vector2(Alex.transform.position.x + 1, Alex.transform.position.y + 0.5f);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="ENEMY")
        {
            if (Alex.GetComponent<Animator>().GetBool("Melee")==true && player.MeleeComplete==true && collision.gameObject.GetComponent<Enemy>().Dead==false)
            {
                Physics2D.IgnoreCollision(Alex.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
                collision.gameObject.GetComponent<Animator>().SetBool("STABBED", true);
                player.MeleeComplete = false;

            }
        }
    }
}
