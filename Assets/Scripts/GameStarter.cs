using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    // transition to main game scene
    public void StartGame()
    {
        SceneManager.LoadScene("new3rdperson");
    }
}
