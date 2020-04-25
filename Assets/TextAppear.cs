using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public GameObject billboard;
    public GameObject b2;
    // Start is called before the first frame update
    void Start()
    {
        billboard.SetActive(false);
        b2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider) {
        if (collider.tag == "Player") {
            billboard.SetActive(true);
            b2.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider collider) {
        billboard.SetActive(false);
        b2.SetActive(false);
    }
}
