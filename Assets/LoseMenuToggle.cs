using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseMenuToggle : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    //PlayerStats player = new PlayerStats();

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }

    void Update()
    {
        if (PlayerStats.Instance.Health <= 0)
        {
            Debug.Log("lose menu toggle - lose entered");
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;

            Time.timeScale = 0f;
        }
    }
}
