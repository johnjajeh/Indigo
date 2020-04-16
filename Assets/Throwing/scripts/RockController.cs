using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
	public GameObject firePoint;

	public GameObject item;

	public bool CanThrow = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if(Input.GetAxisRaw("Aim") != 0) {
		    	if(Input.GetButtonDown("Fire1")){ //&& Can Trhow
		    		// Debug.Log("rock thrown");
		    		// item.GetComponent<MeshRenderer>().enabled = true;
		    		// //item.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
		    		// item.GetComponent<Rigidbody>().AddForce(playerCam.transform.forward * throwForce);
		    		// item.transform.parent = null;
		    		newRock();
		    	}
    	}

        
    }

    void newRock() {
    	GameObject instRock;
    	if(firePoint != null) {
    			Debug.Log("rock inst");
    			instRock = Instantiate(item, firePoint.transform.position, Quaternion.identity);
    		} else {
    			Debug.Log("No Fire Point");
    		}
    }

    // void OnCollisionEnter(Collision collision) {
    // 	if(collision.gameObject.tag == "Player") {
    // 		Destroy(gameObject);
    // 	}
    // }
    // void OnTriggerEnter(Collider collider) {
    //     if(collider.gameObject.tag == "Ground") {
    //        // ScriptThatYouWant.Heal(1.0);
    //     	CanThrow = true;
    //     	Debug.Log("Destroy rock");
    //         Destroy(gameObject);
    //     }
    // }
}
