using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {
	public bool recording = true;
	
	void Update () {
		Recording();
		SkipLevel();
	}
	
	void Recording(){
		if(CrossPlatformInputManager.GetButton("Fire1")){
			recording = false;
		} else {
			recording = true;
		}
	}
	
	void SkipLevel(){
		if(CrossPlatformInputManager.GetButtonDown("Fire3")){
			int currentLevel = Application.loadedLevel;
			print("currentLevel: " + currentLevel);
			
			Application.LoadLevel(currentLevel + 1);
//			PlayerPrefsManager.UnlockLevel(currentLevel + 1);
//			if(PlayerPrefsManager.IsLevelUnlocked(currentLevel + 1)){
//				Application.LoadLevel(currentLevel + 1);
//			}
		}
	}
}
