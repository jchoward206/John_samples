using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject forceVolume;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && forceVolume){
			print ("fire!");
			Instantiate(forceVolume, this.transform.position, Quaternion.identity);
		}
	}
}
