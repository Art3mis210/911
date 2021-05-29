using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Survival_Player : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public Sprite Player1;
    public Sprite Player2;
    public Image PlayerImagePanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "ALEX 2037")
        {
            PlayerImagePanel.sprite = Player1;
        }
        else if (gameObject.name == "ALEX 2035")
        {
            PlayerImagePanel.sprite = Player2;
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        if(gameObject.name == "ALEX 2037")
        {
            PlayerImagePanel.sprite = Player1;
        }
        else if (gameObject.name == "ALEX 2035")
        {
            PlayerImagePanel.sprite = Player2;
        }
    }

}

