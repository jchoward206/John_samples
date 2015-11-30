using UnityEngine;
using System.Collections;

public class MovePiece : MonoBehaviour {

	public Transform[] pieceArray;
	
	private int	newPiece;
	private Transform thisPiece;
	private float moveDelay = 0.1f;
	private float moveLast = 0f;
	
	private int gridSizeX = 10;
	private int gridSizeY = 20;
		
	// Use this for initialization
	void Start () {
		newPiece = 0;
		thisPiece = Instantiate (pieceArray[newPiece], transform.position, Quaternion.identity) as Transform;
		thisPiece.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(moveLast >= moveDelay && Input.anyKeyDown){
			KeyDown();
		} else {
			moveLast += Time.deltaTime;
		}
		
	}
	
	void KeyDown (){		
		moveLast = 0;
		
		if(Input.GetKey(KeyCode.Q)){
			RotatePiece (--newPiece);										// rotate counter-clockwise
		}else if (Input.GetKey(KeyCode.E)){
			RotatePiece (++newPiece);										// rotate clockwise
		}else if (Input.GetKey(KeyCode.A)){
			transform.position += Vector3.left;								// move left
		}else if (Input.GetKey(KeyCode.D)){
			transform.position += Vector3.right;							// move right
		}else if (Input.GetKey(KeyCode.S)){
			transform.position += Vector3.down;								// move down
		}
		
		KeepInBounds();														// make sure nothing leaves the play space

	}
	
	void RotatePiece (int index){
	
		
		if(index > (pieceArray.Length - 1)){								// get the index for the new child piece
			newPiece = 0;
		}else if (index < 0){
			newPiece = pieceArray.Length - 1;
		}else {
			newPiece = index;
		}
	
		for ( int i=transform.childCount-1; i>=0; --i )						// destroy the old one, create the new one
		{
			GameObject child = transform.GetChild(i).gameObject;
			Destroy( child );
		}

		thisPiece = Instantiate (pieceArray[newPiece], transform.position, Quaternion.identity) as Transform;
		thisPiece.transform.parent = this.transform;
		
	}
	
	void KeepInBounds(){
		Transform[] allChildren = transform.GetComponentsInChildren<Transform>();
		
		foreach (Transform square in allChildren){
			if(square.GetComponent<SpriteRenderer>()){						//only evaluate if the child has a sprite renderer (skip the container)
			
				float x = square.transform.position.x;
				float y = square.transform.position.y;
				
				if(x > (gridSizeX-1)){										
					this.transform.position += Vector3.left;				// move left
				}else if (x < 0){
					this.transform.position += Vector3.right;				// move right
				}else if(y > (gridSizeY-1)) {								
					this.transform.position += Vector3.down;				//	move down
				}else if (y < 0) {
					this.transform.position += Vector3.up;					// move up
				}
			}
		}
	}
}
