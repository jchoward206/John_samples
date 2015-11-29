using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Button[] buttonArray;
	private Color buttonDark;

	// Use this for initialization
	void Start () {
		// set all Button sprite render to Button Black
		buttonArray = GameObject.FindObjectsOfType<Button>();
		buttonDark = new Vector4(0,0,0,0.5f); // black with 50% alpha
		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = buttonDark;
		}
		
		DisplayStarCost();
	}

	void DisplayStarCost(){
		Text costLabel = GetComponentInChildren<Text>();
		if(!costLabel){
			Debug.LogWarning(name + " has no cost label");
		}
		
		costLabel.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
	
	void OnMouseDown(){
		foreach(Button thisButton in buttonArray){
			thisButton.GetComponent<SpriteRenderer>().color = buttonDark;
		}
	
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = GetComponent<Button>().defenderPrefab;
	}
	
}
