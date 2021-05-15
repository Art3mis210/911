using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Survival_Level : MonoBehaviour, IPointerEnterHandler
{
    public Sprite Level1;
    public Sprite Level2;
    public Sprite Level3;
    public Sprite Level4;
    public Sprite Level5;
    public Sprite Level6;
    public Image LevelImagePanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "LEVEL 1")
        {
            LevelImagePanel.sprite = Level1;
        }
        else if (gameObject.name == "LEVEL 2")
        {
            LevelImagePanel.sprite = Level2;
        }
        else if (gameObject.name == "LEVEL 3")
        {
            LevelImagePanel.sprite = Level3;
        }
        else if (gameObject.name == "LEVEL 4")
        {
            LevelImagePanel.sprite = Level4;
        }
        else if (gameObject.name == "LEVEL 5")
        {
            LevelImagePanel.sprite = Level5;
        }
        else if (gameObject.name == "LEVEL 6")
        {
            LevelImagePanel.sprite = Level6;
        }
    }

}


