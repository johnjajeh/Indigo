using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleActivator : MonoBehaviour
{
     public GameObject apple;          // Apple prefab
    private Animator appleAnim;       // Apple animation controller
   
    void OnTriggerEnter(Collider c)
    {   
        // Check if apple has not been collected
        if(c.gameObject.tag == "Player") 
        {
            // Check if object in proximity to an apple can collect it
            AppleCollector ac = c.gameObject.GetComponent<AppleCollector>();
            if (ac) 
            {
                // Get animator component of the apple
                appleAnim = apple.GetComponent<Animator>();
                // Set apple animation state to Activated
                appleAnim.SetBool("isActivated", true);
            }
        }
    }

    void OnTriggerExit(Collider c) 
    {
        if(c.gameObject.tag == "Player") 
        {
            // Check if object in proximity to an apple can collect it
            AppleCollector ac = c.gameObject.GetComponent<AppleCollector>();
            if (ac) 
            {
                // Set compass animation state to Idle
                appleAnim.SetBool("isActivated", false);
            }
        }   
    }
}
