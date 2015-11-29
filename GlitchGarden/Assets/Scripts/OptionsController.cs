using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;
	public Text difficultyLabel;
	public LevelManager levelManager;
	
	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	public void SetDefaults(){
		volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
	
	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);

		//return to Start screen
		levelManager.LoadLevel("01 Start");
	}
	
	// Update is called once per frame
	void Update () {
		// piece of shit returns NullReferenceException unless we start from scene 00 Splash. fuck.
		musicManager.SetVolume(volumeSlider.value);
	}
}
