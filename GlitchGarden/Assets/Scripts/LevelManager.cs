using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public int autoLoadNextLevelDelay;
	
	void Start(){
		if(autoLoadNextLevelDelay <= 0){
			Debug.Log("Level auto load disabled, needs a positive number in seconds");
		} else{
			Invoke("LoadNextLevel", autoLoadNextLevelDelay);
		}
	}
	
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel +1);
	}
	
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

}
