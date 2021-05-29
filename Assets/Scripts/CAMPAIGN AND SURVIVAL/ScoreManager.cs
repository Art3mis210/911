using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int MeleeKills;
    public int GunKills;
    public int Hacks;
    void Start()
    {
        MeleeKills = 0;
        GunKills = 0 ;
        Hacks=0;
    }
}
