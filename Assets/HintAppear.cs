using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintAppear : MonoBehaviour
{
    public GameObject[] hints;
    private int currentHint = 0;
    private float timeSinceLastKeyPress = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < hints.Length; i++) {
            hints[i].SetActive(false);
        }
        hints[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastKeyPress += Time.deltaTime;

        if (timeSinceLastKeyPress >= 5) {
            hints[currentHint].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            hints[currentHint].SetActive(false);
            currentHint = (currentHint+1) % hints.Length;
            hints[currentHint].SetActive(true);
            timeSinceLastKeyPress = 0.0f;
        }
    }
}
