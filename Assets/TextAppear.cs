using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public GameObject billboard;
    // Start is called before the first frame update
    void Start()
    {
        billboard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collider) {
        billboard.SetActive(true);
    }
    public void OnTriggerExit(Collider collider) {
        billboard.SetActive(false);
    }
}
