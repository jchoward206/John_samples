using UnityEngine;
using System.Collections;

public class ForcePunch : MonoBehaviour {
	public float damage = 20f;
	public float attackDuration = 0.5f;
	
	//TODO if collider IS Zombie, set to target, apply force to target, make target go ragdoll
	//TODO write a method for cleaning up "dead" zombies

	void OnTriggerEnter (Collider collider){

		if(collider.tag == "zombie"){
			print ("hit zombie!");
			Health health = collider.gameObject.GetComponent<Health>();
			
			if(health){
				health.DealDamage(damage);
			}
		}		
	}
	
	void Update(){
		Destroy(gameObject, attackDuration); 	//destroy force volume after a time
	}
}
