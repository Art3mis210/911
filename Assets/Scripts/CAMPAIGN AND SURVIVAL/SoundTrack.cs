using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SoundTrack : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    // Start is called before the first frame update
    private AudioSource audioS;
    public string Track;
    public string Artist;
    public Text TrackName;
    public Text ArtistName;
    public AudioClip SoundT;
    void Start()
    {
        audioS = GameObject.Find("BackgroundMainMusic").GetComponent<AudioSource>();
    }
    public void OnSelect(BaseEventData eventData)
    {
        TrackName.text = Track;
        ArtistName.text = Artist;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        TrackName.text = Track;
        ArtistName.text = Artist;
    }
    public void PlaySoundtrack()
    {
        audioS.clip = SoundT;
        audioS.Play();
    }
}
