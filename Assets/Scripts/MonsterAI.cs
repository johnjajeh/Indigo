using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class MonsterAI : MonoBehaviour {

    public BasicBehaviour ethanScript;

    private Animator anim;
    UnityEngine.AI.NavMeshAgent nM;
    public GameObject[] waypoints;
    // private int currWaypoint;
	public AIState aiState;
	public VelocityReporter velocity;
    public GameObject goMovingWP;

    public enum AIState {
		frozen, // let it go
        chasingPlayer,
		attackingPlayer
	};

    public double timeElapsed;

    private void setMovingWaypoint() {
        // Debug.Log("Moving toward waypoint!");
		float distance0 = (goMovingWP.transform.position - nM.transform.position).magnitude;
    	float lookAheadT = distance0 / nM.speed;
        Vector3 target = (goMovingWP.transform.position + (lookAheadT * velocity.Velocity));
        // Debug.Log(target);
    	nM.SetDestination(target);
    }

    private Vector3 getDistance() {
    	float distance1 = (goMovingWP.transform.position - nM.transform.position).magnitude;
    	float lookAheadT = distance1 / nM.speed;
    	return (goMovingWP.transform.position + (lookAheadT * velocity.Velocity));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        nM = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nM.stoppingDistance = 1.0f;
        anim = GetComponent<Animator>();
        velocity = gameObject.AddComponent<VelocityReporter>();
        aiState = AIState.chasingPlayer;

        ethanScript = goMovingWP.GetComponent<BasicBehaviour>();
        
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update() {

    	float distance = getDistance().magnitude;

        switch(aiState) {
            case AIState.frozen:
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= 5) {
                    aiState = AIState.chasingPlayer;
                }
                break;        
            case AIState.chasingPlayer:
                setMovingWaypoint();
                if (!nM.pathPending && nM.remainingDistance - nM.stoppingDistance <= 3) {
                    // setNextWaypoint();   
                    aiState = AIState.attackingPlayer;
                    // anim.SetFloat("vely", nM.velocity.magnitude / nM.speed);
                }

                break;        
            case AIState.attackingPlayer:
                // to do: implement actual attack

                ethanScript.reduceHealth();
                timeElapsed = 0;
                aiState = AIState.frozen;

                break;
        }    
    
    }
}