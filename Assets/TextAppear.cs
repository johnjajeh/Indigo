﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public GameObject billboard;
    // Start is called before the first frame update
    void Start()
    {
        billboard.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        billboard.active = true;
    }

    void OnTriggerExit(Collider collider) {
        billboard.active = false;
    }
}
