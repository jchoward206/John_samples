using UnityEngine;
using System.Collections;

public class HoverAudio : MonoBehaviour {
	public AudioSource jetSound;
	public AudioSource windSound;
	
	private float jetPitch;
	
	private const float LowPitch = 0.1f;
	private const float HighPitch = 2f;
	private const float LowVolume = 0.1f;
	private const float HighVolume = 0.5f;
	private const float SpeedToRevs = 0.01f;
	private const float InputToRevs = 0.3f;
	
	private Vector3 myVelocity;
	private Rigidbody carRigidBody;
	private DriveController driveController;
	
	// Use this for initialization
	void Awake () {
		carRigidBody = GetComponent<Rigidbody>();
		driveController = GetComponent<DriveController>();
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
		myVelocity = carRigidBody.velocity;
		float forwardSpeed = transform.InverseTransformDirection(carRigidBody.velocity).z;
		float engineRevs = (Mathf.Abs(forwardSpeed) * SpeedToRevs) + (Mathf.Abs(driveController.powerInput) * InputToRevs);		// engine pitch is a product of speed and input demand
		float windSpeed = Mathf.Abs(forwardSpeed) * SpeedToRevs;
		jetSound.pitch = Mathf.Clamp(engineRevs, LowPitch, HighPitch);
		windSound.volume = Mathf.Clamp(windSpeed, LowVolume, HighVolume);
	}
}
