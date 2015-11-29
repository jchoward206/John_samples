using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health;
	public GameObject ragdoll;
	
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
	
	void DestroyObject(){
		// destroy the zomibe AI
		Destroy(gameObject);

		//create a ragdoll in it's place
		GameObject body = Instantiate(ragdoll, transform.position, Quaternion.identity) as GameObject;
		body.GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
	}
	
}
