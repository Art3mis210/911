using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoScene : MonoBehaviour
{
    // Start is called before the first frame update
    private VideoPlayer CreditVideo;
    private bool LoadNext;
    public string Scene;
    void Start()
    {
        CreditVideo = GetComponent<VideoPlayer>();
        LoadNext = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CreditVideo != null)
            if ((CreditVideo.frame) > 0 && (CreditVideo.isPlaying == false) && LoadNext == false)
            {
                LoadNext = true;
                SceneManager.LoadScene(Scene);

            }
    }
}