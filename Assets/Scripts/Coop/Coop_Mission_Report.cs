using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coop_Mission_Report : MonoBehaviour
{
    public Text MeleeKills;
    public Text GunKills;
    public Text Hacks;
    public Text MeleeKills1;
    public Text GunKills1;
    void Start()
    {
        ScoreManager Score = GameObject.Find("ALEX").GetComponent<ScoreManager>();
        MeleeKills.text += Score.MeleeKills.ToString();
        GunKills.text += Score.GunKills.ToString();
        if (Score.Hacks != 0)
            Hacks.text += Score.Hacks.ToString();
        else
            Destroy(Hacks);
        ScoreManager Score1 = GameObject.Find("ALEX_2035").GetComponent<ScoreManager>();
        MeleeKills1.text += Score1.MeleeKills.ToString();
        GunKills1.text += Score1.GunKills.ToString();
    }

}