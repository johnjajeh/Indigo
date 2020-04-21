using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetMarkerController : MonoBehaviour
{
    public Canvas hud;
    public Camera camera;

    // --- Player + Components --- //
    public GameObject player;
    private CompassCollector cc;
     private TargetStatus targetStatus;

    // --- Marker Image + Display --- //
    private Image marker;                       // Target marker sprite
    private float minX, maxX, minY, maxY;       // Constraints for positioning marker image on screen
    private Text distText;                      // Text displaying player's distance to target
    private float markerStartTime;              // Time when marker is activated
    public float maxMarkerTime;                 // Amount of time marker is visible after compass is collected
    
    // --- Compass Target --- //
    [Tooltip("TRANSFORMS ORDER: gate key, gate, house key, house")]
    public Transform[] targetTransforms;        // Transforms for target objects IN ORDER THEY SHOULD BE COLLECTED
    private const int GATE_KEY = 0, GATE = 1, HOUSE_KEY = 2, HOUSE = 3;             // Indices of targetTransforms

    void Start()
    {
        hud.enabled = false;
        marker = GetComponent<Image>();
        distText = GetComponentInChildren<Text>();
        cc = player.GetComponent<CompassCollector>();
        targetStatus = player.GetComponent<TargetStatus>();
    }

    void Update() 
    {
        if (cc.hasCompass == true || hud.enabled == true) 
        {
            // Start marker when player has compass
            if (cc.hasCompass == true) {
                markerStartTime = Time.time;
                // Debug.Log("marker start time: " + markerStartTime);
            }

            // Enable HUD when player has a compass
            if (hud.enabled == false) {
                hud.enabled = true;
                // Reset player compass status
                cc.hasCompass = false;
            }

            // Debug.Log("has compass: " + cc.hasCompass);
            // Debug.Log("HUD enabled: " + hud.enabled);

            // Set marker for next target: gate key --> gate --> house key --> house
            if (targetStatus.hasHouseKey == true) {
                // Display marker for house
                DisplayMarker(targetTransforms[HOUSE]);
            } else if (targetStatus.hasOpenedGate == true) {
                // Display marker for house key
                DisplayMarker(targetTransforms[HOUSE_KEY]);
            } else if (targetStatus.hasGateKey == true) {
                // Display marker for gate
                DisplayMarker(targetTransforms[GATE]);
            } else {
                // Display marker for gate key
                DisplayMarker(targetTransforms[GATE_KEY]);
            }
        }
        
    }

    private void DisplayMarker(Transform target) 
    {
        // Update screen positioning constraints
        minX = marker.GetPixelAdjustedRect().width/2;
        minY = marker.GetPixelAdjustedRect().height/2;
        maxX = Screen.width-minX;
        maxY = Screen.width-minY;

        // Set marker to target position on screen
        Vector2 tempMarkerPos = camera.WorldToScreenPoint(target.position);

        // If target is behind player, display marker on opposite side of screen
        if (Vector3.Dot(target.position - player.transform.position, player.transform.forward) < 0) {
            if (tempMarkerPos.x < Screen.width/2) {
                tempMarkerPos.x = maxX;
            } else {
                tempMarkerPos.x = minX;
            }
        }

        // Constrain marker to display within screen bounds
        tempMarkerPos.x = Mathf.Clamp(tempMarkerPos.x, minX, maxX);
        tempMarkerPos.y = Mathf.Clamp(tempMarkerPos.y, minY, maxY);

        // Update compass HUD
        marker.transform.position = tempMarkerPos;
        distText.text = Vector3.Distance(player.transform.position, target.position).ToString("f1") + "m";

        // Disable compass HUD after some time
        if (Time.time - markerStartTime > maxMarkerTime) {
            hud.enabled = false;
        }
    }
}
