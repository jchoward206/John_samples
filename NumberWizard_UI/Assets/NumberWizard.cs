using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max;
	int min; 
	int guess;
	
	public int maxGuessesAllowed;
	public Text text;
	
	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	void StartGame(){
		max = 1001;
		min = 1; 
		maxGuessesAllowed = 6;
		NextGuess();

		text.text = "Is your number " + guess.ToString() + "?";
	}
	
	public void GuessHigher(){
		min = guess;
		NextGuess();
	}
	
	public void GuessLower(){
		max = guess;
		NextGuess();
	}
	
	void NextGuess(){
		guess = Random.Range(min,max+1);
		maxGuessesAllowed = maxGuessesAllowed - 1;
		
		text.text = "Is your number " + guess.ToString()+"?\n" +
					"I have " + maxGuessesAllowed.ToString() + " guesses remaining.";
		
		if(maxGuessesAllowed <= 0){
			Application.LoadLevel("Win");
		}
	}
}
