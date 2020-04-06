using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToHouseScene : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider == null)
        {
            throw new System.ArgumentNullException(nameof(collider));
        }

        if (collider.CompareTag("Player") && Key.hasKey)
        {
            Debug.Log("collision detected");
            SceneManager.LoadScene(sceneName);
        }
    }
}