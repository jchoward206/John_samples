using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;
			
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(gameObject);
		Debug.Log("don't destory on load:" + name);
	}
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip levelMusic = levelMusicChangeArray[level];
		Debug.Log("playing clip: " + levelMusic);
		
		if(levelMusic){//if the PersistentMusic array isn't empty...
			audioSource.clip = levelMusic;
			audioSource.loop = true;
			audioSource.Play ();
		}
	}
	
	public void SetVolume(float volume){
		audioSource.volume = volume;
	}
	
}
