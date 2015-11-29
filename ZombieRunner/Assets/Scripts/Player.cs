using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public Transform playerSpawnPoints;	// parent of the spawn points
	public GameObject landingAreaPrefab;
	
	private Transform[] spawnPointsArray;
	private bool respawnToggle;
	private Transform clearArea;
	
	// Use this for initialization
	void Start () {
		spawnPointsArray = playerSpawnPoints.GetComponentsInChildren<Transform>();
	}
	
	void Update(){
		ReSpawn ();
	}
	
	void ReSpawn(){
		if (!respawnToggle){
			return;
		} else {
			int i = Random.Range(1, spawnPointsArray.Length);	
			transform.position = spawnPointsArray[i].transform.position;
			Debug.Log("Player spawned at: " + spawnPointsArray[i]);
	
			respawnToggle = false;
		}	
	}
	
	void OnFindClearArea(){
		clearArea = GetComponentInChildren<ClearArea>().transform;
		Invoke("DropFlare", 3f);
	}
	
	void DropFlare(){
		print (name + " drop flare");
		// drop a flare
		Instantiate(landingAreaPrefab, clearArea.position, clearArea.rotation);
	}
}
