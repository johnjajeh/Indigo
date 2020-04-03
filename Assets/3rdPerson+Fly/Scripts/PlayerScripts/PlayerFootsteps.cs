using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource footsteps;					// AudioSource for footstep sound.

    void Start()
    {
        footsteps = GetComponent<AudioSource>();
    }
   
    public void TakeStep()
    {
        footsteps.Play();
    }
}
