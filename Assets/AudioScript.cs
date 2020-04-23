using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource keySound;
    public AudioSource compassSound;
    public AudioSource appleSound;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision) {
        GameObject g = collision.gameObject;
        Debug.Log("In trigger! Tag is " + g.tag);
        if (g.tag == "Compass") {
            compassSound.Play();
        } else if (g.tag == "Apple") {
            appleSound.Play();
        } else if (g.tag == "Key") {
            keySound.Play();
        }
    }
}
