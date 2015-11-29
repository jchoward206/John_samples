using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = paddle.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {	
		if (!hasStarted){
			// lock the ball relative to the paddle
			this.transform.position = paddle.transform.position - paddleToBallVector;
		
			// wait for a mouse click to launch
			if (Input.GetMouseButtonUp(0)){
				print ("Mouse left click, launch ball");					
				hasStarted = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(1.5f,2.5f), Random.Range(9f,11f));					
			}
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
	// ball doesn't trigger sound when brick is destroyed 100% of the time
	// performance or order of operations issue...
		
		Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f,0.2f));
		
		if(hasStarted){
			GetComponent<AudioSource>().Play();
			this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity + tweak;	
			
//			// clamp the velocity of the ball
//			// has issues where balls stutters occassionally
//			Vector2 newVelocity = this.rigidbody2D.velocity + tweak;
//			float maxVelocity = 9f;
//			
//			if (newVelocity.x > 0.1) {	newVelocity.x = Mathf.Clamp(newVelocity.x, 0.1f, maxVelocity);
//			}else						newVelocity.x = Mathf.Clamp(newVelocity.x, (maxVelocity = -maxVelocity), 0.1f);
//
//			if (newVelocity.y > 0.1) {	newVelocity.y = Mathf.Clamp(newVelocity.y, 0.1f, maxVelocity);
//			}else						newVelocity.y = Mathf.Clamp(newVelocity.y, (maxVelocity = -maxVelocity), 0.1f);
//			
//			this.rigidbody2D.velocity = newVelocity;
			
		}
	}

}
