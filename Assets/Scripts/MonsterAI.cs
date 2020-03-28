using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]

public class MonsterAI : MonoBehaviour {

    public PlayerStats PlayerStatsObj = null;
    private Animator anim;
    UnityEngine.AI.NavMeshAgent nM;
    public GameObject[] waypoints;
    // private int currWaypoint;
	public AIState aiState;
	public VelocityReporter velocity;
    public GameObject goMovingWP;
    public double cutoffDistanceToMovingWaypoint = 2.0;

    private int currWaypoint;

    public enum AIState {
		frozen, // let it go
        chasingPlayer,
		attackingPlayer,
        patrolling
	};

    public double timeElapsed;

 
    
    // Start is called before the first frame update
    void Start()
    {
        nM = GetComponent<UnityEngine.AI.NavMeshAgent>();
        nM.stoppingDistance = 1.0f;
        anim = GetComponent<Animator>();
        velocity = gameObject.AddComponent<VelocityReporter>();
        aiState = AIState.patrolling;


        timeElapsed = 0;
        currWaypoint = 0;
    }

    // Update is called once per frame
    void Update() {

    	float distance = getDistance().magnitude;

        switch(aiState) {
            case AIState.frozen:
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= 5) {
                    if (amICloseEnoughToEthan()) {
                        aiState = AIState.chasingPlayer;
                    } else {
                        aiState = AIState.patrolling;
                        setNextWaypoint();
                    }
                }
                break;        
            case AIState.chasingPlayer:
                setMovingWaypoint();
                if (!nM.pathPending && nM.remainingDistance - nM.stoppingDistance <= 2) {
                    // setNextWaypoint();   
                    aiState = AIState.attackingPlayer;
                    // anim.SetFloat("vely", nM.velocity.magnitude / nM.speed);
                }

                break;        
            case AIState.attackingPlayer:
                // to do: implement actual attack

                // ethanScript.reduceHealth();
                if (PlayerStatsObj != null) {
                    PlayerStatsObj.TakeDamage((float) 1);
                }
                timeElapsed = 0;
                aiState = AIState.frozen;

                break;
            case AIState.patrolling:
                Debug.Log("I am patrolling to waypoint " + currWaypoint);
                if (!nM.pathPending && nM.remainingDistance - nM.stoppingDistance <= 0.2) {
                    if (amICloseEnoughToEthan()) {
                        Debug.Log("I am close enough to Ethan!");
                        setMovingWaypoint();
                        aiState = AIState.chasingPlayer;
                    } else {
                        setNextWaypoint();
                    }
                }
                break; 
        }
    
    }

    private bool amICloseEnoughToEthan() {
        float distance = Mathf.Abs((nM.transform.position - goMovingWP.transform.position).magnitude);
        return  distance < cutoffDistanceToMovingWaypoint;
    }

    private void setNextWaypoint() {
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        nM.SetDestination(waypoints[currWaypoint].transform.position);
    }

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
}