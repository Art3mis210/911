using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class PlayerSoundManager : MonoBehaviour
{
    public AudioClip Shoot;
    public AudioClip Sprint;
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
    /*    else if(animator.GetBool("Move") == false && animator.GetBool("Shoot") == false || Time.timeScale != 1)
        {
           // Invoke("StopAudio", 5);
        } */
    }
    public void PlayOnceSound(AudioClip Clip)
    {
        if(!AudioPlayer.isPlaying)
            AudioPlayer.PlayOneShot(Clip);
    }
    public void StopAudio()
    {
        AudioPlayer.Stop();
    }
    public void PlayAudioOnLoop(AudioClip Clip)
    {
        if (!AudioPlayer.isPlaying)
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
