using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public GameObject music;
    void Start()
    {
        
        if (FindObjectsOfType<AudioSource>().Length == 0)
        {
            Instantiate(music);
            //   GameObject.Find("Audio(clone)").GetComponent<AudioSource>().Play();
        }
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1)
        {
            Destroy(gameObject);
        }
    }
}
