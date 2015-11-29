using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int score = 0;
	
	private Text text;
	
	void Start(){
		// why is this necessary?
		text = this.GetComponent<Text>();
		Reset();
	}
	
	public void Score(int points){
		Debug.Log("scored points!");
		score += points;
		text.text = score.ToString();
	}
	
	public static void Reset(){
		score = 0;
	}

}
