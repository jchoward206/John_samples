using UnityEngine;
using System.Collections;

public class KeepLevel : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {		
		// lock down rotation
		transform.eulerAngles = Vector3.zero;		
	}
}
