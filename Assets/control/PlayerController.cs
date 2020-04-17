using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private string MoveInputAxis = "Vertical";
	private string TurnInputAxis = "Horizontal";

	public float rotationRate = 360; //angles per second, player can do full rotation in 1 sec

	public float moveRate = 10;

	private Rigidbody rb;

	public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
    	//animations
    	anim.SetFloat("vertical", Input.GetAxis("Vertical"));
    	anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));

    	//movement
    	float moveAxis = Input.GetAxis(MoveInputAxis);
    	float turnAxis = Input.GetAxis(TurnInputAxis);

    	ApplyInput(moveAxis, turnAxis);
     
    }

    private void ApplyInput(float moveInput, float turnInput) {
    	Move(moveInput);
    	Turn(turnInput);
    }

    private void Move(float input) {
    	rb.AddForce(transform.forward * input * moveRate, ForceMode.Force);
    }

    private void Turn(float input) {
    	transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
