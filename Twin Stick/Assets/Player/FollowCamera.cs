using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform player;
	
	private Vector3 positionOffset;
	private GameManager gameManager;
	
	// Use this for initialization
	void Start () {
		positionOffset = transform.position - player.position;
		gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.recording){
			transform.position = player.position + positionOffset;
		}else {			// probably a garbage hack for getting smoother camera on recording playback....
			transform.position = Vector3.Lerp(transform.position, player.position + positionOffset, Time.deltaTime * 2);
		}
	}
}
