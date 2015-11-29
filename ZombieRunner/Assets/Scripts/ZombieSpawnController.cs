using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZombieSpawnController : MonoBehaviour {
	public float spawnDelay = 10;
	public bool spawn = true;
	public bool testing = false;
	
	private List<GameObject> spawners = new List<GameObject>();
	private float lastSpawnTime;
	private Player player;
	private float minSpawnDistance = 10f;
	private float maxSpawnDistance = 50f;
	private Helicopter heli;
	
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Player>();
		heli = FindObjectOfType<Helicopter>();
		
		spawners.AddRange(GameObject.FindGameObjectsWithTag("zombieSpawner"));
		lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(heli.heliCalled || testing){		//wait until helicopter has been called to start spawning zombies!
			TryToSpawn();
		}
	}
	
	public void TryToSpawn (){
		if(spawn && Time.time - lastSpawnTime > spawnDelay){
			lastSpawnTime = Time.time;	
			foreach (GameObject spawner in spawners) {
				// find a spawner within ideal range (not too far, not too close)
				// find an ideal range spawner that isn't being rendered
				float playerToSpawner = Vector3.Distance(spawner.transform.position, player.transform.position);
				
				if(!spawner.GetComponent<Renderer>().isVisible && playerToSpawner > minSpawnDistance && playerToSpawner < maxSpawnDistance){
					print ("zombie spawned!");
					spawner.GetComponent<ZombieSpawner> ().Spawn ();
					return;
				}
			}
			
			Debug.Log("failed to spawn Zombie!");
		}
		
	}
	
}
