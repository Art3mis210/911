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
    private bool CoroutineOver;
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
        CoroutineOver = true;

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
                if(CoroutineOver==true)
                    StartCoroutine(SpawnEnemiesWithGap());
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
        for (int i = 0; i < Enemies.Count; i++)
        {
            if (Enemies[i].GetComponent<Enemy>().Dead == false)
            {
                    Over = false;
                    break;
            }
        }
        if (Over == true)
        {
            /*    for (int i = 0; i < Enemies.Count; i++)
                {
                    Destroy(Enemies[i]);
                }*/
            if(Player.name=="ALEX")
            {
                Player.GetComponent<Player>().Ammo += 10 * Wave;
                
            }
            else
            {
                Player.GetComponent<ALEX_2035>().Remaining_Ammo += 10 * Wave;
            }
            List<GameObject> EnemiesToBeDestroyed= new List<GameObject>();
            EnemiesToBeDestroyed.AddRange(Enemies);
            Enemies.Clear();
            for (int i = 0; i < EnemiesToBeDestroyed.Count; i++)
            {
                StartCoroutine(DestroyEnemies(EnemiesToBeDestroyed[i]));
            }
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
    private IEnumerator DestroyEnemies(GameObject Enemy)
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(Enemy);

    }
    private IEnumerator SpawnEnemiesWithGap()
    {
        CoroutineOver = false;
        yield return new WaitForSeconds(3f);
        if (EnemyNo % 2 == 0)
        {

            GameObject Enemy = (GameObject)Instantiate(EnemyType[EnemyTypeno], new Vector3(RightBound.transform.position.x - 3, RightBound.transform.position.y - 2, 0), Quaternion.identity);
            Enemy.GetComponent<Enemy>().Alex = Player;
            Enemy.GetComponent<Enemy>().FoundPlayer = true;
            Enemy.GetComponent<Enemy>().health = Wave + 1;
            Enemies.Add(Enemy);
        }
        else
        {
            GameObject Enemy = (GameObject)Instantiate(EnemyType[EnemyTypeno], new Vector3(LeftBound.transform.position.x + 3, LeftBound.transform.position.y - 2, 0), Quaternion.identity);
            Enemy.GetComponent<Enemy>().Alex = Player;
            Enemy.GetComponent<Enemy>().FoundPlayer = true;
            Enemy.GetComponent<Enemy>().health = Wave + 1;
            Enemies.Add(Enemy);

        }
        EnemyNo++;
        CoroutineOver = true;

    }
}
