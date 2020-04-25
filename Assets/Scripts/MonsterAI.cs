using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public AudioSource attackNoise;

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
                timeElapsed += Time.deltaTime;
                if (timeElapsed >= 3) {
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
                if (amITooFarAwayToChase()) {
                    
                    anim.SetBool("Chasing", false);
                    anim.SetBool("Patrolling", true);
                    aiState = AIState.patrolling;
                    setNextWaypoint();
                }
                setMovingWaypoint();
                nM.speed = 3.0f;
                if (amICloseEnoughToEthanToAttack()) {
                    anim.SetBool("Chasing", false);
                    anim.SetBool("Attacking", true);

                    new WaitForSeconds(5);

                    Debug.Log("Now attacking player!");
                    aiState = AIState.attackingPlayer;
                }

                break;        
            case AIState.attackingPlayer:
                // ethanScript.reduceHealth();
                if (PlayerStatsObj != null) {
                    PlayerStatsObj.TakeDamage((float) 1);
                }

                timeElapsed = 0;
                anim.SetBool("Attacking", false);
                anim.SetBool("Frozen", true);

                attackNoise.Play();

                aiState = AIState.frozen;


                break;
            case AIState.patrolling:
                nM.speed = 2.0f;
                
                //If the enemy is at a waypoint
                if (!nM.pathPending && nM.remainingDistance - nM.stoppingDistance <= 0.2) {
                    //Check if the enemy if close enough to chase the player
                    if (amICloseEnoughToEthanToChase()) {
                        setMovingWaypoint();
                        anim.SetBool("Patrolling", false);
                        anim.SetBool("Chasing", true);
                        aiState = AIState.chasingPlayer;
                    } else { //Too far away, keep patrolling
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
        return  distance > cutoffDistanceForChasing;
    }


    private void setNextWaypoint() {
        currWaypoint = (currWaypoint + 1) % waypoints.Length;
        nM.SetDestination(waypoints[currWaypoint].transform.position);
        nM.updateRotation = true;
    }

    private void setMovingWaypoint() {
        nM.SetDestination(goMovingWP.transform.position);
    }

    private Vector3 getDistance() {
    	float distance1 = (goMovingWP.transform.position - nM.transform.position).magnitude;
    	float lookAheadT = distance1 / nM.speed;
    	return (goMovingWP.transform.position + (lookAheadT * velocity.Velocity));
    }

    public void OnTriggerEnter(Collider collision) {
        if (collision.tag == "rock") {
            timeElapsed = 0;
            anim.SetBool("Chasing", false);
            anim.SetBool("Patrolling", false);
            anim.SetBool("Attacking", false);
            anim.SetBool("Frozen", true);
            aiState = AIState.frozen;
            
        }
    }
}