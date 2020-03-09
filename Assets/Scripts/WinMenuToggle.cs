using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class WinMenuToggle : MonoBehaviour
{
    public GameObject winMarker;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

    }

    void Update()
    {
        Debug.Log(WinMarker.winEntered);
        if (WinMarker.winEntered) {
            Debug.Log("win menu toggle - win entered");
            if(canvasGroup.interactable)
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
                canvasGroup.alpha = 0f;

                Time.timeScale = 1f;
            }
            else
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                canvasGroup.alpha = 1f;

                Time.timeScale = 0f;
            }
        }
        // if (Input.GetKeyUp(KeyCode.W))
        // {
        //     if(canvasGroup.interactable)
        //     {
        //         canvasGroup.interactable = false;
        //         canvasGroup.blocksRaycasts = false;
        //         canvasGroup.alpha = 0f;

        //         Time.timeScale = 1f;
        //     }
        //     else
        //     {
        //         canvasGroup.interactable = true;
        //         canvasGroup.blocksRaycasts = true;
        //         canvasGroup.alpha = 1f;

        //         Time.timeScale = 0f;
        //     }
        // }
    }
}