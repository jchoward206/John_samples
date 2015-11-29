using UnityEngine;
using System.Collections;

public class RagdollCleanUp : MonoBehaviour {
	private Rigidbody rigidBody;
	private float timer = 0;
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float speed = rigidBody.velocity.magnitude;
		
		// freeze the rigidbody after it settles
		if(speed < 0.5 && timer == 0) {
			rigidBody.constraints = RigidbodyConstraints.FreezeAll;
			timer = Time.time;
		}
		
		// clean it up when I'm not looking
		if(timer >= 3f && !GetComponentInChildren<Renderer>().isVisible){
			Destroy(gameObject);
		}else {
			timer += Time.deltaTime;
		}
	}
}
