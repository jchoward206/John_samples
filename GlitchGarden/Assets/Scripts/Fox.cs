using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : Attacker {

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
		
		if(obj.GetComponent<Stone>()){
			anim.SetTrigger("Jump trigger");
		}else{
			anim.SetBool("IsAttacking", true);
			attacker.Attack(obj);
		}
	}
	
}
