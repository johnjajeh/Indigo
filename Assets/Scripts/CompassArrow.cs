using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassArrow : MonoBehaviour
{
    // private CollectableCompass cc;

    public Transform winTarget;
    public GameObject arrow;

    void Start()
    {
        // cc = new CollectableCompass();
        // Hide compass arrow
        arrow.SetActive(false);
    }

    void Update()
    {
        // Vector3 targetDir = winTarget.position - transform.position;
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), Time.time*1);
        
        // Reveal compass arrow if a compass is collected
        if (CollectableCompass.compassCollected) {
        // if (cc.compassCollected == true) {
            arrow.SetActive(true);
            // Rotate to look in direction of win location
            Vector3 targetDir = winTarget.position - transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDir), Time.time*1);
        }
    }
}
