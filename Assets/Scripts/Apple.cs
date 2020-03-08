using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public PlayerStats PlayerStatsObj = null;
    //ScriptThatYouWant = GameObject.Find("PlayerStats").GetComponent<PlayerStats>();
    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player") {
            if(PlayerStatsObj != null) {
                PlayerStatsObj.Heal((float) 1);
            }
            print("Item pickup");
           // ScriptThatYouWant.Heal(1.0);
            Destroy(gameObject);
        }
    }
}
