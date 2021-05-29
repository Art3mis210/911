using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BACKSTORY : MonoBehaviour
{
    private AudioSource AudioS;
    public string Subtitles;
    public Text SubtitleText;
    private void Start()
    {
        AudioS = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Debug.Log("PLAY AUDIO");
            AudioS.Play();
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            SubtitleText.text = Subtitles;
        }
    }
}
