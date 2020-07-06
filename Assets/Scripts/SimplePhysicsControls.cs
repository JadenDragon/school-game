using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType {Force, Velocity, Position}

public class SimplePhysicsControls : MonoBehaviour {

	public ControlType control;

	public float moveForce;
	public float moveSpeed;
	public float jumpPower;

	Rigidbody rb;

	bool jumpPressed;
	bool grounded;

	void Start() {
		rb=GetComponent<Rigidbody>();			
	}

	private void Update() {
		// Jumping:
		if (Input.GetKeyDown(KeyCode.Space)) {
			jumpPressed=true;
			Debug.Log("Jump is pressed");
		}
	}

	bool CheckGrounded() {
		Vector3 origin = transform.position; // The origin of the ray
		Vector3 direction = new Vector3(0, -1, 0); // A vector pointing down; length doesn't matter
		float maxDistance = 1.4f; // Anything further than this from the origin won't return a hit
		RaycastHit hitInfo;

		Debug.DrawRay(origin, direction * maxDistance, Color.red);

		if (Physics.Raycast(origin, direction, out hitInfo, maxDistance)) {
			// Here you can use hitInfo to check more, 
			// e.g. check the tag of the game object that's hit, or the normal vector				
			this.grounded = true;
			return true;
		}
		return false;
	}

	void FixedUpdate() {
		Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		//Two variants of checking whether we're grounded:

		//if (grounded && jumpPressed) { 
		if (CheckGrounded() && jumpPressed) {
			rb.velocity += new Vector3(0, jumpPower, 0);
			Debug.Log("adding jump velocity" + rb.velocity);
			jumpPressed = false;
			grounded = false;
		}
		switch (control) {
			case ControlType.Position:
				transform.Translate(moveVector * moveSpeed * Time.deltaTime);
				break;
			case ControlType.Force:
				rb.AddForce(moveVector * moveForce);
				break;
			case ControlType.Velocity:
				Vector3 baseVelocity = Vector3.zero;
				baseVelocity.y = rb.velocity.y; // in case we're walking on a slope

				rb.velocity = baseVelocity + moveVector * moveSpeed;
				break;
		}

		
	}

	private void OnCollisionStay(Collision collision) {
		//rb.GetComponent<ChangeColor>();
		if (collision.GetContact(0).normal.y>0.7f) {
			grounded=true;
		}
	}
}

