using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {
	[Tooltip("delay in seconds between spawning")]
	public float spawnDelay;
	
	private float currentSpeed;
	private GameObject currentTarget;
	private Health targetHealth;
	private Animator animator;
	private GameObject parent;
	private Spawner[] spawnerArray;
		
	void Start(){
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(Vector3.left * currentSpeed * Time.deltaTime); // distance == speed * time
		
		if(!currentTarget && animator){
			animator.SetBool("IsAttacking", false);
		}
	}
	
	public void SetSpeed(float speed){
		currentSpeed = speed;
	}
	
	//called from Animtor at the time of the actual attack animation playing back
	public void StrikeCurrentTarget(float damage){		
		if(currentTarget){
			Health health = currentTarget.GetComponent<Health>();		
			if(health){
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack (GameObject obj){
		currentTarget = obj;
	}
}
