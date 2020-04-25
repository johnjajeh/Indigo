using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGate : MonoBehaviour
{
    public GameObject rightGate;
    private Animator rightGateAnim;

    public GameObject leftGate;
    private Animator leftGateAnim;

    public AudioSource creak;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider == null)
        {
            throw new System.ArgumentNullException(nameof(collider));
        }

        if (collider.CompareTag("Player") && Key.hasKey)
        {
            // Get animator component of both gates
            rightGateAnim = rightGate.GetComponent<Animator>();
            leftGateAnim = leftGate.GetComponent<Animator>();

            // Set both gates animation states to Activated
            rightGateAnim.SetBool("isActivated", true);
            leftGateAnim.SetBool("isActivated", true);

            creak.Play();
        }
    }
}