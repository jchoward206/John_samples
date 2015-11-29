using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	private GameObject parent; 
	
	
	// Update is called once per frame
	void Update () {
 		foreach(GameObject thisAttacker in attackerPrefabArray){
 			if(isTimeToSpawn(thisAttacker)){
 				Spawn (thisAttacker);
 			}
 		}
	}
	
	bool isTimeToSpawn(GameObject attacker){
		// if the spawn delay of the attacker has elapsed, spawn the attacker
		float spawnDelay = attacker.GetComponent<Attacker>().spawnDelay;
		float spawnsPerSecond = 1/spawnDelay;
		
		if(Time.deltaTime > spawnDelay){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime;
		int lanes = GameObject.FindObjectsOfType<Spawner>().Length;
	
		if(Random.value < threshold/lanes){
			return true;
		} return false;	
	}
	
	void Spawn (GameObject myGameObject){
		GameObject attacker = Instantiate(myGameObject) as GameObject;
		attacker.transform.parent = transform;
		attacker.transform.position = transform.position;
	}
}
