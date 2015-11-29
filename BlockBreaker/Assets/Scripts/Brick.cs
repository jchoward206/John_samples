using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		// keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if(isBreakable){
			HandleHits();
			AudioSource.PlayClipAtPoint(crack, transform.position, 0.25f);
		}
	}
	
	void HandleHits (){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
			
		} else {
			LoadSprites();
		}
	}
	
	void PuffSmoke() {
		// Instantiate the smoke at the position and rotation of this brick
		GameObject smokePuff = (GameObject)Instantiate(smoke, this.transform.position, Quaternion.identity);
		smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites (){
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex]){ //if there's no sprite, don't try and change the sprite
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else Debug.LogError("Brick sprite missing");
	}

}
