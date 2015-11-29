using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float moveSpeed = 0f;
	public float dropHeight = 0f;
	public float spawnDelay = 0.5f;
	
	private bool movingRight = true;
	private float xmin;
	private float xmax;
	
	// Use this for initialization
	void Start () {
		// calcualte edges of the play space based on camera
		// set xmin and xmax to the edge of the playspace minus half the width of the formation
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMost.x + (0.5f * width);
		xmax = rightMost.x - (0.5f * width);
		
		SpawnUntilFull();
	}
	
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}else{
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		
		// the "||" means OR
		// the ! flips the bool "movingRight"
		if (transform.position.x < xmin){
			movingRight = true;
		} else if (transform.position.x > xmax){
			movingRight = false;	
		}
		
		if(AllMembersDead()){
			Debug.Log("Empty formation!");
			SpawnUntilFull();
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(this.transform.position, new Vector3(width, height, 0));
	}
	
	void MoveFormation(){		
		if (transform.position.x >= xmin) {
			Debug.Log("go left");
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}else if (transform.position.x <= xmin) {
			Debug.Log("go right");
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
	}

	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;	
		}
		if(NextFreePosition()){
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}
	
	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in this.transform){
			if(childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}
		}
		return null;
	}	
	
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in this.transform){
			if(childPositionGameObject.childCount > 0){
				return false;
			}
		}
		return true;
	}
}
