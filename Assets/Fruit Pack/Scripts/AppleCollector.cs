using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollector : MonoBehaviour
{
    // Allows attached object to collect a compass
    public bool hasApple = false;

    public void ReceiveApple() {
        hasApple = true;
    }
}
