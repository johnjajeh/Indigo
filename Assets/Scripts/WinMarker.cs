using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinMarker : MonoBehaviour
{
    public static bool winEntered = false; 
    void OnTriggerEnter(Collider c)
    {
        Debug.Log("winMarker trigger entered");
        winEntered = true;
        Debug.Log(winEntered);
    }
}
