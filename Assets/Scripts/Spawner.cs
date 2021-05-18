using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject RightBound;
    public GameObject LeftBound;
    private int Wave;
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Player;
    private bool Spawn;
    private int EnemyNo;
    private List<GameObject> Enemies;
    private List<GameObject> EnemyType;
    public Text WaveNo;
    private int EnemyTypeno;
    void Start()
    {
        Wave = 1;
        Spawn = true;
        EnemyNo = 1;
        Enemies = new List<GameObject>();
        EnemyType = new List<GameObject>(); 
        WaveNo.text = "WAVE  " + Wave.ToString();
        EnemyType.Add(Enemy1.gameObject);
        EnemyType.Add(Enemy2.gameObject);
        EnemyType.Add(Enemy3.gameObject);
        EnemyType.Add(Enemy4.gameObject);
        EnemyTypeno = 0;

    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();

    }
    private void SpawnEnemies()
    {
        if (Spawn == true)
        {
            if (EnemyNo <= Wave + 1)
            {
                if (EnemyNo % 2 == 0)
                {
                    GameObject Enemy = (GameObject)Instantiate(EnemyType[EnemyTypeno], new Vector3(RightBound.transform.position.x - 3, RightBound.transform.position.y-2, 0), Quaternion.identity);
                    Enemy.GetComponent<Enemy>().Alex = Player;
                    Enemy.GetComponent<Enemy>().FoundPlayer = true;
                    Enemy.GetComponent<Enemy>().health = 2;
                    Enemies.Add(Enemy);
                }
                else
                {
                    GameObject Enemy = (GameObject)Instantiate(EnemyType[EnemyTypeno], new Vector3(LeftBound.transform.position.x + 3, LeftBound.transform.position.y-2, 0), Quaternion.identity);
                    Enemy.GetComponent<Enemy>().Alex = Player;
                    Enemy.GetComponent<Enemy>().FoundPlayer = true;
                    Enemy.GetComponent<Enemy>().health = 2;
                    Enemies.Add(Enemy);

                }
                EnemyNo++;
            }
            else
                Spawn = false;

        }
        else
        {
            CheckWaveOver();
        }
    }
    private void CheckWaveOver()
    {
        bool Over = true;
        for(int i=0;i<Enemies.Count ;i++)
        {
            if(Enemies[i].GetComponent<Enemy>().Dead==false)
            {
                Over = false;
                break;
            }
        }
        if(Over==true)
        {
         /*   for (int i = 0; i < Enemies.Count; i++)
            {
                Destroy(Enemies[i]);
            }*/
            Enemies.Clear();
            Wave = Wave + 1;
            EnemyNo = 1;
            Spawn = true;
            WaveNo.text = "WAVE  " + Wave.ToString();
            if (EnemyTypeno != 3)
                EnemyTypeno++;
            else
                EnemyTypeno = 0;

        }
    }
}
