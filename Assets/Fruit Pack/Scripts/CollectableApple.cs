using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableApple : MonoBehaviour
{
     public static bool appleCollected = false;

    void OnTriggerEnter(Collider c) 
    {
        if(c.attachedRigidbody) 
        {
            // Check if object entering trigger can collect an apple
            AppleCollector ac = c.attachedRigidbody.gameObject.GetComponent<AppleCollector>();
            if (ac) 
            {
                appleCollected = true;
                // Destroy collected apple
                Destroy(this.transform.parent.gameObject);
                // Destroy(this.gameObject);
            }
        }
    }
}
