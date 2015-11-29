using UnityEngine;
using System.Collections;

public class Eyes : MonoBehaviour {	
	public float speed = 8f;
	
	private Camera eyes;
	private float defaultFOV;
	private float targetFOV;
	
	// Use this for initialization
	void Start () {
		eyes = GetComponent<Camera>();
		defaultFOV = eyes.fieldOfView;
		targetFOV = eyes.fieldOfView / 1.5f;
	}
	
	void Update(){
		if (Input.GetButton("Zoom")) {
			if(eyes.fieldOfView >= targetFOV){
				eyes.fieldOfView = Mathf.Lerp(eyes.fieldOfView, targetFOV, Time.deltaTime * speed);	
			}
		} else {
			if(eyes.fieldOfView <= defaultFOV){
				eyes.fieldOfView = Mathf.Lerp(eyes.fieldOfView, defaultFOV, Time.deltaTime * (speed * 2f));	
			}
		}
	}

}
