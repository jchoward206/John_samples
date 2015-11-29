using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyLabelUpdate : MonoBehaviour {

	public Text difficultyLabelText;
	
	private Slider slider;
	
	void Update(){
	
		slider = GetComponent<Slider>();
		
		Debug.Log("slider " + slider.value);
		
		if(slider.value == 1f){				difficultyLabelText.text = "Easy";
		} else if (slider.value == 2f){		difficultyLabelText.text = "Medium";
		} else if (slider.value == 3f){		difficultyLabelText.text = "Hard";
		} 
	}
	
}
