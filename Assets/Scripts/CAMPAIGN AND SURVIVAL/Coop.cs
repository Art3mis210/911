using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Coop : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public Sprite Level;
    public Image ImagePanel;
    public Text Title;
    public string TitleText;

    private void Start()
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
         ImagePanel.sprite = Level;
         Title.text= TitleText;
    }
    public void OnSelect(BaseEventData eventData)
    {
        ImagePanel.sprite = Level;
        Title.text=TitleText;
    }
}

