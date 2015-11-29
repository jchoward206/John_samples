using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private Helicopter heli;
	private ZombieSpawnController zombieSpawnController;
	
	// Use this for initialization
	void Start () {
		heli = FindObjectOfType<Helicopter>();
		zombieSpawnController = FindObjectOfType<ZombieSpawnController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(heli.heliCalled){			//start spawning Zombies after Helicopter has been called
			zombieSpawnController.TryToSpawn();
		}
	}
}
