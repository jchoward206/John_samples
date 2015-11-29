using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float fadeInTime;	//length of the fade
	public Color fadeColor;		//fade color
	public bool fadeTo;			//sets fade to (true) or fade from (false)

	private Image fadePanel;
	private Color currentColor;
	
	// Use this for initialization
	void Start () {
		fadePanel = GetComponent<Image>();
		currentColor = fadeColor;
		if (fadeTo){	
			currentColor.a = 0; 		// set alpha to full transparent
		} else currentColor.a = 1;	// set alpha to full opaque
	}
	
	// Update is called once per frame
	void Update () {	
		if(Time.timeSinceLevelLoad < fadeInTime){
			float alphaChange = Time.deltaTime / fadeInTime;

			if(fadeTo){	
				currentColor.a += alphaChange;	//fade to fadeColor.a of 0 to 1
			} else { 		
				currentColor.a -= alphaChange;	//fade from fadeColor.a of 1 to 0
			}

			fadePanel.color = currentColor; 
		}else if(!fadeTo){						
			gameObject.SetActive(false);		//disable this object so buttons are clickable
		}
	}

//	method from the lesson, keeping in case I need it...	
//	// Update is called once per frame
//	void Update () {
//		if(Time.timeSinceLevelLoad < fadeInTime){
//			// fade in
//			float alphaChange = Time.deltaTime / fadeInTime;
//			currentColor.a -= alphaChange;
//			fadePanel.color = currentColor; 
//		}else gameObject.SetActive(false);
//	}
}
