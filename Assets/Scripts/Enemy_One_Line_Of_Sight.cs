using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_One_Line_Of_Sight : MonoBehaviour
{
    public GameObject Enemy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Enemy.GetComponent<Enemy_One>().FoundPlayer = true;
        }
    }
}
