using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class AJMovement : MonoBehaviour
{

	Animator animator;
	CharacterController characterController;

	[System.Serializable]
	public class AnimationSettings{
		public string verticalVelocityFloat = "Forward";
		public string horizontalVelocityFloat = "Strafe";
		public string groundedBool = "isGrounded";
		public string jumpBool = "isJumping";


	}

	[SerializeField]
	public AnimationSettings animations;

	[System.Serializable]
	public class PhysicsSettings {
		public float gravityModifier = 9.81f;
		public float baseGravity = 50.0f;
		public float resetGravityValue = 1.2f;

	}
	[SerializeField]
	public PhysicsSettings physics;

	[System.Serializable]
	public class MovementSettings {
		public float jumpSpeed = 6;
		public float jumpTime = 0.25f;

	}
	[SerializeField]
	public MovementSettings movement;
	bool jumping;
	bool resetGravity;
	float gravity;
	bool isGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        SetupAnimator();

    }

    // Update is called once per frame
    void Update()
    {
    	ApplyGravity();
    	isGrounded = characterController.isGrounded;
        // Animate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));

        // if(Input.GetButtonDown("Jump")) {
        // 	Jump();
        // }
    }

    //animate the character also motion
    public void Animate(float forward, float strafe) {
    	animator.SetFloat(animations.verticalVelocityFloat, forward);
    	animator.SetFloat(animations.horizontalVelocityFloat, strafe);
    	animator.SetBool(animations.groundedBool, isGrounded);
    	animator.SetBool(animations.jumpBool, jumping);
    }

    public void Jump() {
    	if(jumping) {
    		return;
    	}
    	if(isGrounded) {

    		jumping = true;
    		StartCoroutine(StopJump());
    	}
    }

    IEnumerator StopJump() {
    	yield return new WaitForSeconds(movement.jumpTime);
    	jumping = false;
    }

    void ApplyGravity(){
    	if(!characterController.isGrounded) {
    		if(!resetGravity) {
    			gravity = physics.resetGravityValue;
    			resetGravity = true;
    		}
    		gravity += Time.deltaTime * physics.gravityModifier;
    	} else {
    		gravity = physics.baseGravity;
    		resetGravity = false;
    	}

    	Vector3 gravityVector = new Vector3();

    	if(!jumping) {
    		gravityVector.y -= gravity; //maybe movement.gravity
    	} else {
			gravityVector.y = movement.jumpSpeed;
    	}

    	characterController.Move(gravityVector * Time.deltaTime);
    }

    //sets up animator for child avatar
    private void SetupAnimator() {
    	
    	Animator[] animators = GetComponentsInChildren<Animator>();

    	if(animators.Length > 0) {
    		for(int i = 0; i < animators.Length; i++) {
    			Animator anim = animators[i];
    			Avatar av = anim.avatar;

    			if(anim != animator) {
    				animator.avatar = av;

    				Destroy(anim);
    			}
    		}
    	}
    }


}
