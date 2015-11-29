using UnityEngine;
using System.Collections;

public class InnerVoice : MonoBehaviour {
	public AudioClip whatHappened;
	public AudioClip goodLanding;
	
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = whatHappened;
		audioSource.Play();
	}
	
	void OnFindClearArea(){
		print (name + "OnFindClearArea");
		audioSource.clip = goodLanding;
		audioSource.Play ();
		
		Invoke("CallHeli", goodLanding.length + 1f);
	}
	
	void CallHeli(){
		SendMessageUpwards("OnMakeInitialHeliCall");		
	}
}
