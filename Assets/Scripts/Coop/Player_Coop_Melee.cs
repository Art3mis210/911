using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Coop_Melee : MonoBehaviour
{
    public GameObject Alex;
    private Player_Coop player;
    public SoundManager soundManager;
    public AudioClip Stab;
    public AudioClip Knockout;

    void Start()
    {
        player = Alex.GetComponent<Player_Coop>();
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
        if (collision.gameObject.name.Contains("ENEMY HAZARD UNIT"))
        {

            if (Alex.GetComponent<Animator>().GetBool("Melee") == true && player.MeleeComplete == true && collision.gameObject.GetComponent<Enemy_Coop>().Dead == false && collision.gameObject.GetComponent<Enemy_Coop>().Rest == false)
            {
                if (Alex.GetComponent<Animator>().GetBool("Pistol") == false)
                    soundManager.PlayOnceSound(Stab);
                Physics2D.IgnoreCollision(Alex.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
                collision.gameObject.GetComponent<Animator>().SetBool("STABBED", true);
                player.MeleeComplete = false;
                collision.gameObject.GetComponent<Enemy_Coop>().Rest = true;
                Destroy(collision.gameObject.transform.GetChild(0).gameObject);
                Destroy(collision.gameObject.transform.GetChild(1).gameObject);


            }
            else if (Alex.GetComponent<Animator>().GetBool("Melee") == true && player.MeleeComplete == true && collision.gameObject.GetComponent<Enemy_Coop>().Dead == false && collision.gameObject.GetComponent<Enemy_Coop>().Rest == true)
            {
                if (Alex.GetComponent<Animator>().GetBool("Pistol") == true)
                    soundManager.PlayOnceSound(Knockout);
                else
                    soundManager.PlayOnceSound(Stab);
                collision.gameObject.GetComponent<Animator>().SetBool("DEATH", true);
                player.MeleeComplete = false;
                Alex.GetComponent<ScoreManager>().MeleeKills++;
            }
        }
        else if (collision.gameObject.tag == "ENEMY" && collision.gameObject.name.Contains("ENEMY HAZARD UNIT") == false)
        {
            if (Alex.GetComponent<Animator>().GetBool("Melee") == true && player.MeleeComplete == true && collision.gameObject.GetComponent<Enemy_Coop>().Dead == false)
            {
                if (Alex.GetComponent<Animator>().GetBool("Pistol") == true)
                    soundManager.PlayOnceSound(Knockout);
                else
                    soundManager.PlayOnceSound(Stab);
                Physics2D.IgnoreCollision(Alex.GetComponent<BoxCollider2D>(), collision.gameObject.GetComponent<BoxCollider2D>(), true);
                collision.gameObject.GetComponent<Animator>().SetBool("STABBED", true);
                player.MeleeComplete = false;
                Alex.GetComponent<ScoreManager>().MeleeKills++;

            }
        }
    }
}
