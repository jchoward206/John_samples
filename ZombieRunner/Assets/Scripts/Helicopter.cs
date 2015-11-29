using UnityEngine;
using System.Collections;

public class Helicopter : MonoBehaviour {
	public float duration = 10f;
	public bool heliCalled = false;
	
	private bool heliReachedHoverPos = false;
	private Rigidbody rigidBody;	
	private Transform landingArea;
	private Vector3 heliEndPos;
	private Transform heliStart;
	private float startTime;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	void Update(){
		FlyHeli ();
		LandHeli ();
	}
	
	void OnDispatchHelicopter(){
		Debug.Log("helicopter called");
			
		heliCalled = true;		
		heliStart = rigidBody.transform;												// get the heli start position for later
		landingArea = GameObject.FindGameObjectWithTag("landingArea").transform;		// get the landing area to send heli there later
		heliEndPos = new Vector3(landingArea.position.x, landingArea.position.y + 30, landingArea.position.z);
		startTime = Time.time;
	}
	
	void FlyHeli (){		
		if (heliCalled && !heliReachedHoverPos) {
			// move the heli to hover over the landing area
			rigidBody.transform.position = Vector3.Lerp (heliStart.position, heliEndPos, (Time.time - startTime) / duration);
		} else if (heliReachedHoverPos) {
			// move heli to the ground
			rigidBody.transform.position = Vector3.Lerp (heliStart.position, heliEndPos, (Time.time - startTime) / 200);
		}
	}

	void LandHeli (){
		//if the heli has reacht the landing area, tell it to land by updating a new start and end position
		float nearHovPos = Vector3.Distance (rigidBody.transform.position, heliEndPos);
		
		if (!heliReachedHoverPos && nearHovPos < 10f) {
			heliReachedHoverPos = true;
			heliStart = rigidBody.transform;
			heliEndPos = landingArea.position;
			startTime = Time.time;
		}
	}
}
