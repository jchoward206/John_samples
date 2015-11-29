using UnityEngine;
using System.Collections;

public class Stone : Defender {
	private Animator animator;
	
	void Start(){
		animator = gameObject.GetComponent<Animator>();
	}
	
	void OnTriggerStay2D(Collider2D collider){
		Attacker attacker = collider.GetComponent<Attacker>();
		if(!attacker){
			return;
		}
		animator.SetTrigger("TakingDamageTrigger"); 		
	}
	
}
