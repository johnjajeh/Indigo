using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public static bool hasKey;

    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player") {
            Debug.Log("Key pickup");
            hasKey = true;
            TargetStatus ts = GameObject.FindGameObjectWithTag("Player").GetComponent<TargetStatus>();
            ts.hasGateKey = true;
            Destroy(gameObject);
        }
    }
}
