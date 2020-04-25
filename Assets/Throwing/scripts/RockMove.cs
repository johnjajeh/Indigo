using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
	public float fireRate;
	//public Transform playerCam;
	private GameObject objCamera;
	private GameObject firepoint;
	public float throwForce;
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    	objCamera = (GameObject) GameObject.FindWithTag("MainCamera");
    	firepoint = (GameObject) GameObject.FindWithTag("Firepoint");
    	rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (throwForce != 0){
    		//transform.position += transform.forward * (speed * Time.deltaTime);
    		// var controlDirection : Vector3 = Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    		// var actualDirection = objCamera.TransformDirection(controlDirection);
    		rb.AddForce(firepoint.transform.forward * throwForce); //objCamera.transform.forward
    	} else {
    		Debug.Log("No Speed");
    	}
        
    }

    void OnCollisionEnter() {
    	// Debug.Log("destroyed rock");
    	rb.velocity = Vector3.zero;
    	rb.angularVelocity = Vector3.zero;
    	rb.drag = 10;
    	rb.constraints &= ~RigidbodyConstraints.FreezePositionZ;
    	rb.constraints &= ~RigidbodyConstraints.FreezePositionX;
    	rb.constraints &= ~RigidbodyConstraints.FreezePositionY;

    	Destroy(gameObject);
    }
}
