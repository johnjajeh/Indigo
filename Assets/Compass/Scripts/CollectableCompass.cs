using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCompass : MonoBehaviour
{
    public static bool compassCollected = false;

    void OnTriggerEnter(Collider c) 
    {
        if(c.attachedRigidbody) 
        {
            // Check if object entering trigger can collect a compass
            CompassCollector cc = c.attachedRigidbody.gameObject.GetComponent<CompassCollector>();
            if (cc) 
            {
                compassCollected = true;
                // Destroy collected compass
                Destroy(this.transform.parent.gameObject);
                // Destroy(this.gameObject);
            }
        }
    }
}
