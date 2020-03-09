using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassCollector : MonoBehaviour
{
    // Allows attached object to collect a compass
    public bool hasCompass = false;

    public void ReceiveRock() {
        hasCompass = true;
    }
}
