using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityReporter : MonoBehaviour {
	private Vector3 prevPos;

	public Vector3 RawVelocity {
		get;
        private set;
    }

	public Vector3 Velocity	{
		get;
        private set;
    }

	public float smoothingTimeFactor = 0.5f; private Vector3 smoothingParamVel;

	// Use this for initialization
	void Start () {
		prevPos = this.transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		RawVelocity = (this.transform.position - prevPos) / Time.deltaTime;
		Velocity = Vector3.SmoothDamp(Velocity, RawVelocity, ref smoothingParamVel, smoothingTimeFactor);
		prevPos = this.transform.position;
	}
}
