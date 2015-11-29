using UnityEngine;
using System.Collections;

public class ClearArea : MonoBehaviour {
	public Collider terrain;
	public float timeSinceLastTrigger = 0f;

	private bool foundClearArea = false;
	
	// Update is called once per frame
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;
		
		if(timeSinceLastTrigger > 1f && Time.realtimeSinceStartup > 10f && !foundClearArea){
			print (name + "found a clear area");
			SendMessageUpwards("OnFindClearArea");
			foundClearArea = true;
		}
	}
	
	void OnTriggerStay(Collider collider){		//stupid OnTriggerStay requires rigidbody on object....
		if(collider.tag == "terrain" || collider.tag == "river" && collider.tag != "player"){
			timeSinceLastTrigger = 0f;
		} 
	}
}
