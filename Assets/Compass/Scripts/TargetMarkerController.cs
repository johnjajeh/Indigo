using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMarkerController : MonoBehaviour
{
    public Canvas hud;
    private Image marker;                   // Target marker sprite
    private Text distText;                  // Text displaying player's distance to target
    public Transform target;                // Transform of target object
    public GameObject player;               // Player object
    public Camera camera;                   // Camera
    private float markerStartTime;          // Time when marker is activated
    public float maxMarkerTime;             // Amout of time marker remains visible
    private CompassCollector cc;            // CompassCollector

    void Start()
    {
        hud.enabled = false;
        marker = GetComponent<Image>();
        distText = GetComponentInChildren<Text>();
        cc = player.GetComponent<CompassCollector>();
    }

    void Update() 
    {
        if (cc.hasCompass == true) 
        {
            // Enable HUD when player has a compass
            if (hud.enabled == false) {
                hud.enabled = true;
            }

            // Debug.Log("has compass: " + cc.hasCompass);
            // Debug.Log("HUD enabled: " + hud.enabled);

            if (target != null) 
            {
                // Update distance text
                float dist = Vector3.Distance(player.transform.position, target.position);
                distText.text = dist.ToString("f1") + "m";

                // Disable HUD after a certain time
                if (Time.time - markerStartTime > maxMarkerTime)
                {
                    hud.enabled = false;
                }
            }
        }
        
    }
}
