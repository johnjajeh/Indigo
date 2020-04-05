using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour
{
	public float fireRate;
	//public Transform playerCam;
	private GameObject objCamera;
	public float throwForce;
	private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
    	objCamera = (GameObject) GameObject.FindWithTag("MainCamera");
    	rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (throwForce != 0){
    		//transform.position += transform.forward * (speed * Time.deltaTime);
    		rb.AddForce(rb.transform.forward * throwForce);
    	} else {
    		Debug.Log("No Speed");
    	}
        
    }

    void OnCollisionEnter() {
    	Debug.Log("destroyed rock");
    	rb.drag = 10;
    	Destroy(gameObject, 2.0f);
    }
}
