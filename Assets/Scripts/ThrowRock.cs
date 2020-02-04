using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour
{
    public GameObject player;
    public GameObject rock;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            createRock();
            throwIt();
        }
    }

    void createRock() {
        Instantiate(rock, player.transform.position, player.transform.rotation);
        Debug.Log("Player Pos: " + player.transform.position);
        Debug.Log("Rock Pos: " + rock.transform.position);
    }

    void throwIt() {
    }
}
