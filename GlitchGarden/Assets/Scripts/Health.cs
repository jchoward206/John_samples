using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	
	// Use this for initialization
	void Start () {
	
	}
	
	public void DealDamage(float damage){
		health -= damage;
		if(health < 0){
			//optionally trigger death animation
			// Destroy object can be triggered from animation timeline to sync anim and death event
			DestroyObject();
		}
	}
	
	public void DestroyObject(){
		Destroy(gameObject);
	}
	
}
