using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableApple : MonoBehaviour
{
    public static bool appleCollected = false;
    // private CharacterController charController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

    // void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     if (hit.collider.gameObject.name == "Apple") {

    //     }
    // }

    void OnTriggerEnter(Collider c) 
    {
        if(c.gameObject.tag == "Player") 
        {
            // Check if object entering trigger can collect an apple
            AppleCollector ac = c.gameObject.GetComponent<AppleCollector>();
            if (ac) 
            {
                appleCollected = true;
                // Destroy collected apple
                Destroy(transform.parent.gameObject);
                // Destroy(this.gameObject);
            }
        }
    }
}
