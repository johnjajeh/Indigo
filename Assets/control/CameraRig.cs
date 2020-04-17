using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraRig : MonoBehaviour
{
	public Transform target;
	public bool autoTargetPlayer;
	public LayerMask wallLayers;

	public enum Shoulder{
		Right,
		Left
	}
	public Shoulder shoulder;

	[System.Serializable]
	public class CameraSettings {
		[Header("-Positioning-")]
		public Vector3 camPositionOffsetLeft;
		public Vector3 camPositionOffsetRight;

		[Header("-Camera Options-")]
		public float mouseXSensitivity = 5.0f;
		public float mouseYSensitivity = 5.0f;
		public float minAngle = -30.0f;
		public float maxAngle = 70.0f;
		public float rotationSpeed = 5.0f;
		public float maxCheckdist = 0.1f;

		[Header("-Zoom-")]
		public float fieldOfView = 70.0f;
		public float zoomFieldOfView = 30.0f;
		public float zoomSpeed = 3.0f;

		[Header("-Visual Options-")]
		public float hideMeshWhenDistance = 0.5f;
	}
	[SerializeField]
	public CameraSettings cameraSettings;

	[System.Serializable]
	public class InputSettings {
		public string verticalAxis = "Mouse X";
		public string horizontalAxis = "Mouse Y";
		public string aimButton = "Fire2";
		public string switchShoulderButton = "Fire4";

	}

	[SerializeField]
	public InputSettings input;

	[System.Serializable]
	public class MovementSettings{
		public float movementLerpSpeed = 5.0f;
	}

	[SerializeField]
	public MovementSettings movement;

	Transform pivot;
	Camera mainCamera;
	float newX = 0.0f;
	float newY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    	mainCamera = Camera.main;
    	pivot = transform.GetChild(0);

        
    }

    // Update is called once per frame
    void Update()
    {
    	if(target) {
    		if(Application.isPlaying) {
    			RotateCamera();
    			CheckWall();
    			CheckMeshRenderer();
    			Zoom(Input.GetButton(input.aimButton));

    			if(Input.GetButtonDown(input.switchShoulderButton)) {
    				SwitchShoulders();
    			}
    		}

    	}
        
    }

    void LateUpdate() {
    	if(!target) {
    		TargetPlayer();
    	}
    	else {
    		Vector3 targetPosition = target.position;
    		Quaternion targetRotation = target.rotation;

    		FollowTarget(targetPosition, targetRotation);
    	}
    }

    //Targets the player and sets it as target
    void TargetPlayer() {
    	if(autoTargetPlayer) {
    		GameObject player = GameObject.FindGameObjectWithTag("Player");
    		
    		if (player) {
    			Transform playerT = player.transform;

    			target = playerT;
    		}
    	}
    }

    //following the target
    void FollowTarget(Vector3 targetPosition, Quaternion targetRotation) {
    	if(!Application.isPlaying) {
    		transform.position = targetPosition;
    		transform.rotation = targetRotation;
    	} else {
    		Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * movement.movementLerpSpeed);
    		transform.position = newPos;
    	}
    }

    //Rotates the camera with input
    void RotateCamera() {
    	if(!pivot) {
    		Debug.Log("No pivot orbit func");
    		return;
    	}

    	Debug.Log("Mouse x " + cameraSettings.mouseXSensitivity);
    	Debug.Log("Mouse y " + cameraSettings.mouseYSensitivity);
    	Debug.Log("Mouse vert pos " + Input.GetAxis(input.verticalAxis));
    	Debug.Log("Mouse horz pos " + Input.GetAxis(input.horizontalAxis));
    	newX += cameraSettings.mouseXSensitivity * Input.GetAxis(input.verticalAxis);
    	newY += cameraSettings.mouseYSensitivity * Input.GetAxis(input.horizontalAxis);

    	Vector3 eurlerAngleAxis = new Vector3();
    	eurlerAngleAxis.x = newY;
    	eurlerAngleAxis.y = newX;

    	newX = Mathf.Repeat(newX, 360); //prevents camera bouncing
    	newY = Mathf.Clamp(newY, cameraSettings.minAngle, cameraSettings.maxAngle);

    	Quaternion newRotation = Quaternion.Slerp(pivot.localRotation, Quaternion.Euler(eurlerAngleAxis), Time.deltaTime * cameraSettings.rotationSpeed);

    	pivot.localRotation = newRotation;

    }

    //checks to see if there is a wall in the way, camera moves up when hit. camera will not get stuck behind walls
    void CheckWall() {
    	if(!pivot || !mainCamera) {
    		return;
    	}

    	RaycastHit hit;

    	Transform mainCamT = mainCamera.transform;
    	Vector3 mainCamPos = mainCamT.position;
    	Vector3 pivotPos = pivot.position;

    	Vector3 start = pivotPos;
    	Vector3 dir = mainCamPos - pivotPos;

    	float dist = Mathf.Abs(shoulder == Shoulder.Left ? cameraSettings.camPositionOffsetLeft.z : cameraSettings.camPositionOffsetRight.z);

    	if(Physics.SphereCast(start, cameraSettings.maxCheckdist, dir, out hit, dist, wallLayers)) {
    		MoveCamUp(hit, pivotPos, dir, mainCamT);
    	}else {
    		switch(shoulder) {
    			case Shoulder.Left:
    				PositionCamera(cameraSettings.camPositionOffsetLeft);
    				break;
    			case Shoulder.Right:
					PositionCamera(cameraSettings.camPositionOffsetRight);
    				break;
    		}
    	}
    }

    //this moves the camera forward when we hit a wall
    void MoveCamUp(RaycastHit hit, Vector3 pivotPos, Vector3 dir, Transform cameraT) {
    	float hitDist = hit.distance;
    	Vector3 sphereCastCenter = pivotPos + (dir.normalized * hitDist);
    	//Vector3 cameraTPose = cameraT.position;
    	cameraT.position = sphereCastCenter;

    }

    //Positions the camera's local pos to the given location
    void PositionCamera(Vector3 cameraPos) {
    	if(!mainCamera) {
    		return;
    	}

    	Transform mainCamT = mainCamera.transform;
    	Vector3 mainCamPos = mainCamT.localPosition;
    	Vector3 newPos = Vector3.Lerp(mainCamPos, cameraPos, Time.deltaTime * movement.movementLerpSpeed);
    	mainCamT.localPosition = newPos;

    }

    //this hides the players meshes when we are too close to the target
    void CheckMeshRenderer(){
    	if(!mainCamera || !target) {
    		return;
    	}
    	SkinnedMeshRenderer[] meshes = target.GetComponentsInChildren<SkinnedMeshRenderer>();
    	Transform mainCamT = mainCamera.transform;
    	Vector3 mainCamPos = mainCamT.position;
    	Vector3 targetPos = target.position; //mayber vec2
    	float dist = Vector3.Distance(mainCamPos, (targetPos + target.up));

    	if(meshes.Length > 0) {
    		for(int i = 0; i < meshes.Length; i++) {
    			if(dist <= cameraSettings.hideMeshWhenDistance) {
    				meshes[i].enabled = false;
    			} else {
    				meshes[i].enabled = true;
    			}
    		}
    	}
    }


    //zooms camera in and out
    void Zoom(bool isZooming) {
    	if (!mainCamera) {
    		return;
    	}
    	if (isZooming) {
    		float newFieldOfView = Mathf.Lerp(mainCamera.fieldOfView, cameraSettings.zoomFieldOfView, Time.deltaTime * cameraSettings.zoomSpeed);
    		mainCamera.fieldOfView = newFieldOfView; 
    	} else {
    		float originalFieldOfView = Mathf.Lerp(mainCamera.fieldOfView, cameraSettings.fieldOfView, Time.deltaTime * cameraSettings.zoomSpeed);
    		mainCamera.fieldOfView = originalFieldOfView;
    	}
    }

    //switches shoudlers for camera perspective
    public void SwitchShoulders() {
    	switch(shoulder) {
    		case Shoulder.Left:
    			shoulder = Shoulder.Right;
    			break;
    		case Shoulder.Right:
    			shoulder = Shoulder.Left;
    			break;
    	}
    }
}
