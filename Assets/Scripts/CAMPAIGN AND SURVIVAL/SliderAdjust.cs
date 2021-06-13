using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SliderAdjust : MonoBehaviour, ISelectHandler
{
    public Scrollbar Scroll;
    public float ScrollValue;
    public void OnSelect(BaseEventData eventData)
    {
        Scroll.value = ScrollValue;
    }
}
