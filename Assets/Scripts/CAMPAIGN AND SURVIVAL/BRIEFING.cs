using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class BRIEFING : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Loading;
    private VideoPlayer Episode;
    void Start()
    {
        Episode = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Episode != null)
            if ((Episode.frame) > 0 && (Episode.isPlaying == false))
            {
                Destroy(Episode);
                Loading.SetActive(true);
                StartCoroutine(LoadYourAsyncScene("LEVEL 1"));

            }
    }
    IEnumerator LoadYourAsyncScene(string SceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (asyncLoad.progress < 1)
        {
            Loading.SetActive(true);
            yield return new WaitForEndOfFrame();
        }
    }
}

