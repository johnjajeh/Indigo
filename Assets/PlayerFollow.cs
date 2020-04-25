using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMesh;
    public GameObject player;
    // Start is called before the first frame update
    private Vector3 previousPosition;
    private float currentSpeed;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.stoppingDistance = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curMove = transform.position - previousPosition;
        currentSpeed = curMove.magnitude / Time.deltaTime;
        previousPosition = transform.position;


        if (currentSpeed > 0) {
            anim.SetBool("Idle", false);
            anim.SetBool("Chasing", true);
        } else {
            anim.SetBool("Chasing", false);
            anim.SetBool("Idle", true);
        }

        navMesh.SetDestination(player.transform.position);
    }
}
