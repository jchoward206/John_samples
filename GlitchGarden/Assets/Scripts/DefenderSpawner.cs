using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	public Camera myCamera;
	
	private GameObject parent;
	private StarDisplay starDisplay;
	
	void Start(){
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		
		parent = GameObject.Find("Defenders");
		if(!parent){
			parent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown(){
		if (!Button.selectedDefender){
			return;
		}
		
		Vector2 rawPos = (CalculateWorldPointAtMouseClick ());
		Vector2 roundedPos = SnapToGrid(rawPos);
		GameObject defender = Button.selectedDefender;
		
		int myStarCost = defender.GetComponent<Defender>().starCost;
		if(starDisplay.UseStars(myStarCost) == StarDisplay.Status.FAILURE){
			Debug.Log("Insufficient stars to spawn");
			return;
		}

		SpawnDefender (roundedPos, defender);
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender){
		GameObject newDefender = Instantiate (defender, roundedPos, Quaternion.identity) as GameObject;
		newDefender.transform.parent = parent.transform;
	}
	
	Vector2 CalculateWorldPointAtMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f; // in ortho view, distance doesn't matter
		
		Vector3 wierdTriplet = new Vector3(mouseX,mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(wierdTriplet);
		
		return worldPos;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY =  Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(newX, newY);
	}
}
