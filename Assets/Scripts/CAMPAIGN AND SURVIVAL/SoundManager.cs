using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    private AudioSource AudioPlayer;
    private Animator animator;
    void Start()
    {
        AudioPlayer = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Time.timeScale != 1)
      {
           StopAudio();
      } 
    }
    public void PlayOnceSound(AudioClip Clip)
    {
        AudioPlayer.Pause(); 
        AudioPlayer.PlayOneShot(Clip);
    }
    public void StopAudio()
    {
        AudioPlayer.Stop();
    }
    public void PlayAudioOnLoop(AudioClip Clip)
    {
        if (!AudioPlayer.isPlaying || AudioPlayer.clip!=Clip)
        {
            AudioPlayer.loop = true;
            AudioPlayer.clip = Clip;
            AudioPlayer.Play();
        }
    }

 /*   public void KeepPlaying(AudioClip clip)
    {
        AudioPlayer.Play(Clip);
    }*/
}
