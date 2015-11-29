using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay = false;
	
	private Ball ball;
	private Vector2 newPaddlePos;
	private Vector2 oldPaddlePos;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
		oldPaddlePos = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		} else{
			AutoPlay();
		}
	}
	
	void MoveWithMouse (){
		Vector3 paddlePos = new Vector3 (1f, this.transform.position.y, 0f);
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,1f,15f);
		
		this.transform.position = paddlePos;
	}
	
	void AutoPlay(){
		Vector3 paddlePos = this.transform.position;
		Vector3 ballPos = ball.transform.position;	
		
		paddlePos.x = Mathf.Clamp(ballPos.x,1f,15f);
		
		this.transform.position = paddlePos;
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		newPaddlePos = this.transform.position;
		
		if(newPaddlePos!=oldPaddlePos){
			PaddleEnglish();			
		}
	}
	
	void PaddleEnglish(){			
		Vector2 paddleVector = newPaddlePos - oldPaddlePos;
		Vector2 tweak = new Vector2();
				
		if(paddleVector.x < -0.5f){
			tweak = new Vector2(Random.Range(-0.5f,-2f), 0.1f);
		}else if(paddleVector.x > 0.5f){
			tweak = new Vector2(Random.Range(0.5f,2f), 0.1f);
		} 
		
		ball.GetComponent<Rigidbody2D>().velocity = ball.GetComponent<Rigidbody2D>().velocity + tweak;
		
		// update stored, old paddle position				
		oldPaddlePos = newPaddlePos;;
	}
}
