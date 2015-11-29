using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {
	public enum Status{SUCCESS, FAILURE};
	
	private Text displayText;
	private int starTotal = 1000;
	
	// Use this for initialization
	void Start () {
		displayText = GetComponent<Text>();
		displayText.text = starTotal.ToString();
	}
	
	public void AddStars(int amount){
		starTotal += amount;
		UpdateDisplay();
	}
		
	public Status UseStars(int amount){
		if (starTotal >= amount){
			starTotal -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay(){
		displayText.text = starTotal.ToString();
	}
}
