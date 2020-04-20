using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMesh;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navMesh.stoppingDistance = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        navMesh.SetDestination(player.transform.position);
    }
}
