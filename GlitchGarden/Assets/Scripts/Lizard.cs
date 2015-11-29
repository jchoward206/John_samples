using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Lizard : Attacker {
	
	private Animator anim;
	private Attacker attacker;
	
	void Start (){
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		GameObject obj = collider.gameObject;
		
		//test false if not colliding with a defender
		if (!obj.GetComponent<Defender>()){
			return;
		}
		
		anim.SetBool("IsAttacking", true);
		attacker.Attack(obj);
	}
}
