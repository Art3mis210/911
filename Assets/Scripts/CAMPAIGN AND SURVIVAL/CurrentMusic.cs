using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentMusic : MonoBehaviour
{
    private Text CurrentlyPlaying;
    private AudioSource audioS;
    private string CurrentTrack;
    void Start()
    {
        audioS= GameObject.Find("BackgroundMainMusic").GetComponent<AudioSource>();
        CurrentTrack = audioS.clip.name;
        CurrentlyPlaying = gameObject.GetComponent<Text>();
        CurrentlyPlaying.text = CurrentTrack;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTrack != audioS.clip.name)
        {
            CurrentTrack = audioS.clip.name;
            CurrentlyPlaying.text = CurrentTrack;
        }
    }
}
