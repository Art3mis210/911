using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSoundTrack : MonoBehaviour
{
    private AudioSource audioS;
    void Start()
    {
        audioS=GameObject.Find("BackgroundMainMusic").GetComponent<AudioSource>();
    }
    public void PlaySoundTrack()
    {
        audioS.Play();
    }
    public void PauseSoundTrack()
    {
        audioS.Pause();
    }
    public void StopSoundTrack()
    {
        audioS.Stop();
    }

}
