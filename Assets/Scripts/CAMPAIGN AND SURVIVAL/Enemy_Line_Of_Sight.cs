using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Line_Of_Sight : MonoBehaviour
{
    public GameObject Enemy;
    public AudioClip Alert;
    private void Update()
    {
        if (Enemy.GetComponent<Enemy>().FoundPlayer == true)
            Destroy(gameObject);
        if (Enemy.GetComponent<SpriteRenderer>().flipX == true)
        {
            transform.position = new Vector2(Enemy.transform.position.x - 4, Enemy.transform.position.y + 2);
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            transform.position = new Vector2(Enemy.transform.position.x + 4, Enemy.transform.position.y + 2);
            gameObject.GetComponent<SpriteRenderer>().flipY = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Enemy.GetComponent<SoundManager>().StopAudio();
            Enemy.GetComponent<SoundManager>().PlayOnceSound(Alert);
            Enemy.GetComponent<Enemy>().FoundPlayer = true;
        }
    }
}
