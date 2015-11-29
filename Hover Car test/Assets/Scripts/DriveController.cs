using UnityEngine;
using System.Collections;

public class DriveController : MonoBehaviour {
	public float speed = 90f;
	public float turnSpeed = 5f;
	public float powerInput;			// public so the audio engine can read it...
	public Transform[] thrusterArray = new Transform[4];
	
	private float turnInput;
	private Rigidbody carRigidBody;
	
	void Awake () {
		carRigidBody = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
		powerInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
	}
	
	void FixedUpdate(){;
		
		carRigidBody.AddRelativeForce(0f, 0f, powerInput * speed);
		
		carRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
		
	}
	
}
