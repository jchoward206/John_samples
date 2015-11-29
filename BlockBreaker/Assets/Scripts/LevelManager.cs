using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		// reset
		Brick.breakableCount = 0;
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
	}
	
	public void LoadNextLevel(){
		// reset
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void QuitRequest(){
		Debug.Log("I want to quit!");
		Application.Quit();
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
