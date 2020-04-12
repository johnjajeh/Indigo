using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public string sceneName;

    // transition to main game scene
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
