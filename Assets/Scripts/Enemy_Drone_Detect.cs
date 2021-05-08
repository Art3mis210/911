using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Drone_Detect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Drone;
    public GameObject DroneHackRange;
    public GameObject Bullet;
    private bool RotateDrone;
    void Start()
    {
        RotateDrone = false;
    }
    private void Update()
    {
        if (DroneHackRange.GetComponent<Enemy_Drone_Hack>().Hacked == true)
            Destroy(gameObject);
        if (Drone.GetComponent<EnemyDrone>().destroyed == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" )
        {
            if (RotateDrone == false)
            {
                Drone.transform.rotation = Quaternion.Euler(0, 0, 90);
            //    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            //   Drone.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
                RotateDrone = true;
            }
            Fire();
        }
    }
    public void Fire()
    {
        Bullet.GetComponent<Bullet>().DroneMode = true;
        Bullet.GetComponent<Bullet>().EnemyMode = false;
        Bullet.GetComponent<Bullet>().PlayerMode = false;
        Instantiate(Bullet, new Vector3(Drone.transform.position.x, Drone.transform.position.y-2, 0), Quaternion.identity);
    }
}
