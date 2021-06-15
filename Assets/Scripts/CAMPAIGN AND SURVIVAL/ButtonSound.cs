using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour
{
    public AudioClip ButtonSelect;
    public AudioClip Pressed;
    private AudioSource audioS;
    private void Awake()
    {
        audioS = GetComponent<AudioSource>();
        audioS.PlayOneShot(Pressed);
    }
    public void OnSelect()
    {
        audioS.PlayOneShot(ButtonSelect);
    }
}
