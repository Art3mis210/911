using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    private AudioSource AudioPlayer;
    private Animator animator;
    public bool StartAudio;
    void Start()
    {
        AudioPlayer = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        StartAudio = true;
    }

    // Update is called once per frame
    void Update()
    {
          if(Time.timeScale != 1 && SceneManager.sceneCount>1 && StartAudio==true)
          {
                AudioPlayer.Pause();
                StartAudio = false;
          } 
          else if (Time.timeScale == 1 && SceneManager.sceneCount == 1 && StartAudio == false)
          {
                AudioPlayer.UnPause();
                StartAudio = true;
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
