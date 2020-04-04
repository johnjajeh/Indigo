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
    public double cutoffDistanceToMovingWaypoint = 8;

    public double cutoffDistanceForAttacking = 2;

    public double cutoffDistanceForChasing = 16;

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
        anim.SetBool("Patrolling", true);
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
                // Debug.Log("Frozen!");
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= 5) {
                    if (amICloseEnoughToEthanToChase()) {
                        anim.SetBool("Frozen", false);
                        anim.SetBool("Chasing", true);
                        aiState = AIState.chasingPlayer;
                    } else {
                        anim.SetBool("Frozen", false);
                        anim.SetBool("Patrolling", true);
                        aiState = AIState.patrolling;
                        setNextWaypoint();
                    }
                }
                break;        
            case AIState.chasingPlayer:
                // Debug.Log("Chasing player!");
                //TODO if the player is too far away, go back to patrolling
                if (amITooFarAwayToChase()) {
                    anim.SetBool("Chasing", false);
                    anim.SetBool("Patrolling", true);
                    aiState = AIState.patrolling;
                    setNextWaypoint();
                }
                setMovingWaypoint();
                nM.speed = 3.0f;
                if (amICloseEnoughToEthanToAttack()) {
                    // setNextWaypoint();   
                    anim.SetBool("Chasing", false);
                    anim.SetBool("Attacking", true);
                    aiState = AIState.attackingPlayer;
                    // anim.SetFloat("vely", nM.velocity.magnitude / nM.speed);
                }

                break;        
            case AIState.attackingPlayer:
                // Debug.Log("Attacking player!");
                // to do: implement actual attack
                
                // ethanScript.reduceHealth();
                if (PlayerStatsObj != null) {
                    PlayerStatsObj.TakeDamage((float) 1);
                }
                if (anim)
                timeElapsed = 0;
                anim.SetBool("Attacking", false);
                anim.SetBool("Frozen", true);
                aiState = AIState.frozen;

                break;
            case AIState.patrolling:
                // Debug.Log("I am patrolling to waypoint " + currWaypoint);
                nM.speed = 2.0f;
                if (!nM.pathPending && nM.remainingDistance - nM.stoppingDistance <= 0.2) {
                    if (amICloseEnoughToEthanToChase()) {
                        setMovingWaypoint();
                        anim.SetBool("Patrolling", false);
                        anim.SetBool("Chasing", true);
                        aiState = AIState.chasingPlayer;
                    } else {
                        setNextWaypoint();
                    }
                }
                break; 
        }
    
    }

    private bool amICloseEnoughToEthanToChase() {
        float distance = Mathf.Abs((nM.transform.position - goMovingWP.transform.position).magnitude);
        return  distance < cutoffDistanceToMovingWaypoint;
    }

    private bool amICloseEnoughToEthanToAttack() {
        float distance = Mathf.Abs((nM.transform.position - goMovingWP.transform.position).magnitude);
        return  distance < cutoffDistanceForAttacking;
    }

    private bool amITooFarAwayToChase() {
                float distance = Mathf.Abs((nM.transform.position - goMovingWP.transform.position).magnitude);
        return  distance < cutoffDistanceForChasing;
    }


    private void setNextWaypoint() {
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        nM.SetDestination(waypoints[currWaypoint].transform.position);
        nM.updateRotation = true;
    }

    private void setMovingWaypoint() {
        // Debug.Log("Moving toward waypoint!");
        // float distance0 = (goMovingWP.transform.position - nM.transform.position).magnitude;
        // float lookAheadT = distance0 / nM.speed;
        // Vector3 target = (goMovingWP.transform.position + (lookAheadT * velocity.Velocity));
        // Debug.Log(target);
        nM.SetDestination(goMovingWP.transform.position);
    }

    private Vector3 getDistance() {
    	float distance1 = (goMovingWP.transform.position - nM.transform.position).magnitude;
    	float lookAheadT = distance1 / nM.speed;
    	return (goMovingWP.transform.position + (lookAheadT * velocity.Velocity));
    }
}