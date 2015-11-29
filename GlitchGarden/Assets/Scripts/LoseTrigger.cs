using UnityEngine;
using System.Collections;

public class LoseTrigger : MonoBehaviour {
	private LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D collider){
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		
		//ignore if we're aren't colliding with an Attacker...
		// if the collider didn't have an Attacker component, it will return NULL
		if(attacker){
			Destroy(gameObject);
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("03 Lose");
		}
		
	}
}
