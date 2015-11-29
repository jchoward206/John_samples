using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {
	public bool spawn;
	public GameObject zombiePrefab;
	
	private GameObject zombie;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void Spawn(){	
 		zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity) as GameObject;	
 		Transform player = FindObjectOfType<Player>().transform;
 		zombie.GetComponent<ZombieCharacterControl>().SetTarget(player);
 	}
}
