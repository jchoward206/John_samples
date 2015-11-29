using UnityEngine;
using System.Collections;

public class RadioSystem : MonoBehaviour {
	public AudioClip initialHeliCall;
	public AudioClip initialHeliCallReply;
	
	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMakeInitialHeliCall(){
		print (name + " OnMakeInitialHeliCall");
		
		audioSource.clip = initialHeliCall;
		audioSource.Play();
		
		Invoke("OnMakeInitialHeliCallReply", initialHeliCall.length + 1f);
	}
	
	void OnMakeInitialHeliCallReply(){
		audioSource.clip = initialHeliCallReply;
		audioSource.Play();
		
		BroadcastMessage("OnDispatchHelicopter");
	}
}
