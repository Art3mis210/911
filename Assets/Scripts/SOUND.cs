using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SOUND : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer AudioMixer;
    public Slider VolumeS;
    private void Start()
    {
        
        float volume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        VolumeS.value = volume;
    }
    //    public AudioMixerGroup AudioMixer_gp;
    public void SetVolume(float volume)
    {
        AudioMixer.SetFloat("volume", volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
