using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitToStartScreen : MonoBehaviour
{
    public void QuitGameToStart()
    {
        SceneManager.LoadScene("startScreen");
    }
}
