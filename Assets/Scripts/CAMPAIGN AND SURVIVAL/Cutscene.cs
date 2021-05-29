using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Cutscene : MonoBehaviour
{
    private VideoPlayer Episode;
    void Start()
    {
        Episode = GetComponent<VideoPlayer>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Episode.frame) > 0 && (Episode.isPlaying == false))
        {
            Time.timeScale = 1;
            Destroy(gameObject);
            
        }
    }
}
