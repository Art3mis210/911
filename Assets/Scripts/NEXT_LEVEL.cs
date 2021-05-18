using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEXT_LEVEL : MonoBehaviour
{
    public Camera MainCamera;
    private bool SceneOver;
    private void Start()
    {
        SceneOver = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player" && SceneOver==false)
        {
            MainCamera.enabled = false;
            SceneOver = true;
            SceneManager.LoadScene("MISSION COMPLETED", LoadSceneMode.Additive);
        }
    }
}
