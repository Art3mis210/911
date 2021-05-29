﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SOUND : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer AudioMixer;
    public Slider MusicVolume;
    public Slider GeneralVolume;
    private void Start()
    {
        
        float Mvolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        MusicVolume.value = Mvolume;
        float Gvolume = PlayerPrefs.GetFloat("GeneralVolume", 0.75f);
        GeneralVolume.value = Gvolume;
    }
    //    public AudioMixerGroup AudioMixer_gp;
    public void SetMusicVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetGeneralVolume(float volume)
    {
        AudioMixer.SetFloat("GeneralVolume", volume);
        PlayerPrefs.SetFloat("GeneralVolume", volume);
    }
}