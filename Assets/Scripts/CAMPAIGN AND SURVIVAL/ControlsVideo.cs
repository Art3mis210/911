using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ControlsVideo : MonoBehaviour, ISelectHandler
{
    public VideoPlayer VideoP;
    public VideoClip VideoC;
    public RawImage RawI;
    public Text Description;
    public string DescriptionText;

    public void OnSelect(BaseEventData eventData)
    {
        Description.text = DescriptionText;
        VideoP.Stop();
        RawI.enabled = false;
    }
    public void PlayVideo()
    {
        RawI.enabled = true;
        Description.text = DescriptionText;
        VideoP.clip = VideoC;
        VideoP.Play();
    }
}
