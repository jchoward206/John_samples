using UnityEngine;
using System.Collections;

public class Suspension : MonoBehaviour {

	public float suspensionRange = 2.50f;
	public float suspensionForce = 500f;
	public float suspensionDamp = 17.00f;
	
	public GameObject levelParent;
	
	private RaycastHit hit;
	private Rigidbody parent;
	private DrawDebugRays drawRay;
	
	void Awake(){
//		hit = GetComponent<RaycastHit>();
		parent = GetComponentInParent<Rigidbody>();
		drawRay = GetComponent<DrawDebugRays>();
	}
	
	void FixedUpdate () {
		Vector3 down = transform.TransformDirection(Vector3.down); 
		Vector3 worldDown = levelParent.transform.TransformDirection(-Vector3.up); 
		Ray ray = new Ray(transform.position, worldDown);
		
		drawRay.DrawThisRay (ray, Color.cyan);
		
		if(Physics.Raycast (ray, out hit, suspensionRange) && hit.collider.transform.root != transform.root)
		{
			print ("go!!!");
			Vector3 velocityAtTouch = parent.GetPointVelocity(hit.point);
			
			float compression = hit.distance / (suspensionRange);
			compression = -compression + 1;
			Vector3 counterForce = -worldDown * compression * suspensionForce;
			
			Vector3 t = transform.InverseTransformDirection(velocityAtTouch);
			t.z = t.x = 0;
			Vector3 shockDrag = levelParent.transform.TransformDirection(t) * -suspensionDamp;
			
			parent.AddForceAtPosition(counterForce + shockDrag, hit.point);
			
		}
	}
}
