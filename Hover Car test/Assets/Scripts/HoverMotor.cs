using UnityEngine;
using System.Collections;

public class HoverMotor : MonoBehaviour {
	public float speed = 90f;
	public float turnSpeed = 5f;
	public float hoverForce = 65f;
	public float hoverHeight =3.5f;
	
	public float powerInput;
	private float turnInput;
	private Rigidbody carRigidBody;
	private DrawDebugRays drawRay;
	
	void Awake () {
		carRigidBody = GetComponent<Rigidbody>();	
		drawRay = GetComponent<DrawDebugRays>();
	}
	
	// Update is called once per frame
	void Update () {
		powerInput = Input.GetAxis("Vertical");
		turnInput = Input.GetAxis("Horizontal");
	}
	
	void FixedUpdate(){
		Ray ray = new Ray (transform.position, -transform.up);
		RaycastHit hit;
		
		drawRay.DrawThisRay (ray, Color.cyan);
		
		if(Physics.Raycast(ray, out hit, hoverHeight)){
			float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
			Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
			carRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);			// ForceMode.Acceleration ignores the mass of the car for better hover action
		}
		
		carRigidBody.AddRelativeForce(0f, 0f, powerInput * speed);
		
		carRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
		
	}
	
}
