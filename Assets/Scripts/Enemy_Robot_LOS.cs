using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Robot_LOS : MonoBehaviour
{
    public GameObject Enemy;
    private void Update()
    {
        if (Enemy.GetComponent<SpriteRenderer>().flipX == true)
            transform.position = new Vector2(Enemy.transform.position.x - 8, Enemy.transform.position.y + 1);
        else
            transform.position = new Vector2(Enemy.transform.position.x + 8, Enemy.transform.position.y + 1);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Enemy.GetComponent<Enemy_Robot>().FoundPlayer = true;
            Destroy(gameObject);
        }
    }
}
