using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {
	private ScoreKeeper scoreKeeper;
	private Text text;
	
	// Use this for initialization
	void Start () {
		text = this.GetComponent<Text>();
		
		text.text = "Your score: " + ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();
	}
}
