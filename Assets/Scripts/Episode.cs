using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Episode : MonoBehaviour, IPointerEnterHandler
{
    public Sprite Level1;
    public Sprite Level2;
    public Sprite Level3;
    public Sprite Level4;
    public Sprite Level5;
    public Sprite Level6;
    public Image ImagePanel;
    public Text Title;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.name == "EPISODE 1")
        {
            ImagePanel.sprite = Level1;
            Title.text = "PROLOGUE";
        }
        else if (gameObject.name == "EPISODE 2")
        {
            ImagePanel.sprite = Level2;
            Title.text = "NIGHT SHIFT";
        }
        else if (gameObject.name == "EPISODE 3")
        {
            ImagePanel.sprite = Level3;
            Title.text = "SLIPPERY WET";
        }
        else if (gameObject.name == "EPISODE 4")
        {
            ImagePanel.sprite = Level4;
            Title.text = "RADIOACTIVE";
        }
        else if (gameObject.name == "EPISODE 5")
        {
            ImagePanel.sprite = Level5;
            Title.text = "DAYS OF FUTURE PAST";
        }
        else if (gameObject.name == "EPISODE 6")
        {
            ImagePanel.sprite = Level6;
            Title.text = "BUTTERFLY EFFECT";
        }
    }
}
    
