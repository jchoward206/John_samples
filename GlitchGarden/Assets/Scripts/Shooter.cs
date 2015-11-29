using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile, gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start(){
		animator = GameObject.FindObjectOfType<Animator>();
		
		projectileParent = GameObject.Find("Projectiles");
		
		// creates a parent if necessary
		if(!projectileParent){
			projectileParent = new GameObject("Projectiles");
	 	}
	 	
		SetLaneSpawner();
	}
	
	void Update(){
		//if there's an attacker in front of me in my lane, shoot
		//if not, don't shoot
		if (isAttackerAheadInLane()){
			animator.SetBool("IsAttacking", true);
		}else{
			animator.SetBool("IsAttacking", false);			
		}
	}
	
	bool isAttackerAheadInLane(){		
		// exit if no attackers in lane
		if(myLaneSpawner.transform.childCount <= 0){
			return false;
		}
		
		foreach(Transform attacker in myLaneSpawner.transform){
			if(attacker.transform.position.x > this.transform.position.x){
				return true;
			}
		}
		return false;
	}
	
	void SetLaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach(Spawner thisSpawner in spawnerArray){
			//find the spawner in my lane
			if (thisSpawner.transform.position.y == this.transform.position.y){		
				myLaneSpawner = thisSpawner;
				return;
			}
		}
		Debug.LogError(name + " can't find spawner in lane.");
	}
	
	private void Fire (){	
		GameObject newProjectile = Instantiate(projectile)as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}

}
