using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 500;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];	
	private Rigidbody rigidBody;
	private GameManager gameManager;
	private int totalWrittenFrames;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.recording){
			Record();
		}else {
			Playback();
		}
	}

	void Record () {
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
		totalWrittenFrames++;
	}
	
	void Playback (){
		rigidBody.isKinematic = true;

		if(totalWrittenFrames > bufferFrames){
			int frame = Time.frameCount % bufferFrames;			
			transform.position = keyFrames [frame].position;
			transform.rotation = keyFrames [frame].rotation;		
		} else {
			int frame = Time.frameCount % totalWrittenFrames;			
			transform.position = keyFrames [frame].position;
			transform.rotation = keyFrames [frame].rotation;		
		}
	}
}

/// <summary>
/// A struct for storing time, rotation and position.
/// </summary>
public struct MyKeyFrame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;
	
	// method with same name as struct / class == CONSTRUCTOR!!!
	public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation){
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;
	}
}