using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStart : MonoBehaviour
{
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene == SceneManager.GetSceneByName("new3rdperson"))
        {
            Time.timeScale = 1;

        }
        else if (currentScene == SceneManager.GetSceneByName("startScene"))
        {
            Time.timeScale = 0;
        }
    }
}
