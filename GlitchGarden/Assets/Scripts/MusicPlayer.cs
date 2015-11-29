using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip splashClip;
	public AudioClip startClip;
	public AudioClip gameClip;
	
	private AudioSource music;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			Debug.Log("play music for splash!");
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = splashClip;
			music.loop = true;
			music.Play();
		}
	}
	
	void OnLevelWasLoaded(int level){
		Debug.Log("music player: loaded level " + level);
		music.Stop();
		
		if(level == 0){
			music.clip = splashClip;
		}
		if(level == 1){
			music.clip = startClip;
		}
		if(level == 2){
			music.clip = gameClip;
		}
		
		music.loop = true;
		music.Play();

	}
}
