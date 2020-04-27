using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCompass : MonoBehaviour
{
    void OnTriggerEnter(Collider c) 
    {
        if(c.gameObject.tag == "Player") 
        {
            // Check if object entering trigger can collect a compass
            CompassCollector cc = c.gameObject.GetComponent<CompassCollector>();
            if (cc) 
            {
                cc.hasCompass = true;
                // Destroy collected compass
                Destroy(this.transform.parent.gameObject);
                // Destroy(this.gameObject);
            }
        }
    }
}