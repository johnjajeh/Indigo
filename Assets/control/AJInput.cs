using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJInput : MonoBehaviour
{
	AJMovement characterMove;

	[System.Serializable]
	public class InputSettings{
		public string verticalAxis = "Vertical";
		public string horizontalAxis = "Horizontal";
		public string jumpButton = "Jump";
		public string aimButton = "Aim";
	}
	[SerializeField]
	InputSettings input;

	[System.Serializable]
	public class OtherSettings {
		public float lookSpeed = 5.0f;
		public float lookDistance = 10.0f;
		public bool requireInputForTurn = true;
	}

	[SerializeField]
	public OtherSettings other;

	Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        characterMove = GetComponent<AJMovement>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(characterMove) {
       		characterMove.Animate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        	if(Input.GetButtonDown("Jump")) {
        		characterMove.Jump();
        	}

        	if(Input.GetButton(input.aimButton)) {
        		characterMove.Aim();
        		if(Input.GetButtonDown("Throw")) {
        			characterMove.Launch();
        		}
        	} else {
        		characterMove.StopAim();
        	}
        }

        if(mainCam) {
        	if(other.requireInputForTurn) {
        		if(Input.GetAxis(input.horizontalAxis) != 0 || Input.GetAxis(input.verticalAxis) != 0) {
        			CharacterLook();
        		}
        	}
        	else {
        		CharacterLook();
        	}
        }
    }

    //tells char to look at the point that is in front of camera
    void CharacterLook() {
    	Transform mainCamT = mainCam.transform;
    	Transform pivotT = mainCamT.parent;
    	Vector3 pivotPos = pivotT.position;
    	//Vector3 mainCamPose = mainCamT.position;
    	Vector3 lookTarget = pivotPos + (pivotT.forward * other.lookDistance);
    	Vector3 thisPos = transform.position;
    	Vector3 lookDir = lookTarget - thisPos;
    	Quaternion lookRot = Quaternion.LookRotation(lookDir);
    	lookRot.x = 0;
    	lookRot.z = 0;
    	Quaternion newRotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * other.lookSpeed);
    	transform.rotation = newRotation;
    }
}
