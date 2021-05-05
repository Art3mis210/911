using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drone_Detect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Drone;
    public GameObject Bullet;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            //  Drone.transform.rotation = Quaternion.Euler(0, 0, 90);
            Fire();
        }
    }
    public void Fire()
    {
        Bullet.GetComponent<Bullet>().DroneMode = true;
        Bullet.GetComponent<Bullet>().EnemyMode = false;
        Bullet.GetComponent<Bullet>().PlayerMode = false;
        Instantiate(Bullet, new Vector3(Drone.transform.position.x, Drone.transform.position.y-1, 0), Quaternion.identity);
    }
}
