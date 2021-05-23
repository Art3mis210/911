using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Sound_Detection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject EnemyParent;
    private SoundManager soundManager;
    public AudioClip Alert;

    private void Start()
    {
        soundManager = EnemyParent.gameObject.GetComponent<SoundManager>();
    }
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
            Enemy enemyScript = EnemyParent.GetComponent<Enemy>();
            if(an.GetBool("Stand")==true && an.GetBool("Move")==true)
            {
                
                if(enemyScript.StayIdle==false)
                {
                    soundManager.StopAudio();
                    soundManager.PlayOnceSound(Alert);
                    enemyScript.FoundPlayer = true;
                    
                }
            }
        }
        if(collision.gameObject.tag=="PDRONE" && Input.GetKeyDown(KeyCode.Q) && EnemyParent.GetComponent<Enemy>().FoundPlayer==false)
        {

            soundManager.StopAudio();
            soundManager.PlayOnceSound(Alert);
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
