using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameAgain : MonoBehaviour
{
    // transition to main game scene
    public void RestartGame()
    {
        SceneManager.LoadScene("new3rdperson");
    }
}
