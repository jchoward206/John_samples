using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour {

	public float hoverForce = 65f;
	public float hoverHeight =3.5f;
	public float rotationRate = 5f;
	
	private Rigidbody carRigidBody;
	private DrawDebugRays drawRay;
	
	void Awake () {
		carRigidBody = GetComponentInParent<Rigidbody>();	
		drawRay = GetComponentInParent<DrawDebugRays>();
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
		
	}
	
	/// <summary>
	/// Test code for moving thrusters 
	/// </summary>
	
	// get input an rotate thruster via animation controller...
	
//	void Update(){
//		if(Input.GetAxis("Vertical")> 0.2f){
//			ForwardThrust();
//		} else if (Input.GetAxis("Vertical") < -0.2f){
//			BackwardThrust();
//		}
//	}
	
	void IdleThrust(){
		print ("Idle");
		StartCoroutine( RotateMe(Vector3.zero, 1f));
	}
	
	void ForwardThrust(){
		print ("forward!!!");
		StartCoroutine( RotateMe(new Vector3(60f, 0,0), 1f) );
	}
	
	void BackwardThrust(){
		print ("backward!!!");
		StartCoroutine( RotateMe(new Vector3(-60f, 0,0), 1f) );
	}
	
	IEnumerator RotateMe(Vector3 byAngles, float inTime) {
		Quaternion fromAngle = transform.rotation;
		Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
		for(float t = 0f; t < 1; t += Time.deltaTime/inTime) {
			transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t);
			yield return null;
		}
	}
}
