using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelTimeMax = 10f;
	private float levelTimeElapsed = 0f;
	private Slider gameTimerUI;
	private bool levelEnded = false;
	private AudioSource winMusic;
	private LevelManager levelManager;
	private GameObject winLabel;
	
	// Use this for initialization
	void Start () {
		SetTimer();
		FindWinLabel();
		winLabel.SetActive(false);
	}
	
	void SetTimer(){
		gameTimerUI = GetComponent<Slider>();
		gameTimerUI.maxValue = levelTimeMax;
		gameTimerUI.value = 0f;
	}

	void UpdateTimer(){
		levelTimeElapsed += Time.deltaTime;
		gameTimerUI.value = levelTimeElapsed;
	}	
	
	// Update is called once per frame
	void Update () {
		UpdateTimer();
		
		bool timeIsUp = (levelTimeElapsed >= levelTimeMax);
		if (timeIsUp && levelEnded == false){
			LevelWon ();
			levelEnded = true;
		}
	}

	void FindWinLabel (){
		winLabel = GameObject.Find("You Win");
		if (!winLabel){
			Debug.LogWarning("Win label missing.");
		}
	}

	static void DestroyTaggedObjects (){
		GameObject[] taggedObjectArray;
		taggedObjectArray = GameObject.FindGameObjectsWithTag ("DestroyOnWin");
		foreach (GameObject thisObject in taggedObjectArray) {
			if (thisObject.CompareTag ("DestroyOnWin")) {
				Debug.Log (thisObject.name + " should be destroyed");
				DestroyObject (thisObject);
			}
		}
	}
	
	void LevelWon(){
		//destroy all objects tagged "DestroyOnWin"
		DestroyTaggedObjects ();

		// display a win message and play audio
		winLabel.SetActive(true);
		winMusic = GetComponent<AudioSource>();
		winMusic.Play();
	
		// load the next level	
		Invoke("LoadNextLevel", winMusic.clip.length);
	}
	
	void LoadNextLevel(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadNextLevel();
	}
}
