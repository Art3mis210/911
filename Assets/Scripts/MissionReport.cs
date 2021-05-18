using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MissionReport : MonoBehaviour
{
    public Text MeleeKills;
    public Text GunKills;
    public Text Hacks;
    void Start()
    {
        ScoreManager Score = GameObject.FindGameObjectWithTag("Player").GetComponent<ScoreManager>();
        MeleeKills.text +=Score.MeleeKills.ToString();
        GunKills.text +=Score.GunKills.ToString();
        if (Score.Hacks != 0)
            Hacks.text +=Score.Hacks.ToString();
        else
            Destroy(Hacks);
    }

}
