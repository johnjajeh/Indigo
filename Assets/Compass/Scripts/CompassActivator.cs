using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassActivator : MonoBehaviour
{
    public GameObject compass;          // Compass prefab
    private Animator compassAnim;       // Compass animation controller
   
    void OnTriggerEnter(Collider c)
    {   
        // Check if compass has not been collected
        if(c.gameObject.tag == "Player") 
        {
            // Check if object in proximity to a compass can collect it
            CompassCollector cc = c.gameObject.GetComponent<CompassCollector>();
            if (cc) 
            {
                // Get animator component of the compass
                compassAnim = compass.GetComponent<Animator>();
                // Set compass animation state to Activated
                compassAnim.SetBool("isActivated", true);
            }
        }
    }

    void OnTriggerExit(Collider c) 
    {
        if(c.gameObject.tag == "Player") 
        {
            // Check if object in proximity to a compass can collect it
            CompassCollector cc = c.gameObject.GetComponent<CompassCollector>();
            if (cc) 
            {
                // Set compass animation state to Idle
                compassAnim.SetBool("isActivated", false);
            }
        }   
    }
}
