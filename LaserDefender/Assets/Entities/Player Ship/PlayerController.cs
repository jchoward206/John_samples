using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float shipMoveSpeed = 0f;
	public float padding = 0f;
	public float health = 200f;
	public GameObject laserPrefab;
	public float laserMoveSpeed = 0f;
	public float laserRateOfFire = 0.2f;
	public bool godMode = false;
	
	private float xmin;
	private float xmax;
	private LevelManager levelManager;
	
	// Use this for initialization
	void Start () {
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	}
	
	// Update is called once per frame
	void Update () {
		MoveWithKeyboard();

		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("FireLaser", 0.01f, laserRateOfFire);
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("FireLaser");
		}	
	}

	void MoveWithKeyboard(){
		if (Input.GetKey(KeyCode.LeftArrow)){
			transform.position += Vector3.left * shipMoveSpeed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow)){	
			transform.position += Vector3.right * shipMoveSpeed * Time.deltaTime;
		}
		
		// restrict player ship to the game space
		float newX = Mathf.Clamp(transform.position.x, xmin, xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
	
	void FireLaser(){
		Vector3 startPosition = this.transform.position + new Vector3(0,0.5f,0);
		GameObject laser = Instantiate(laserPrefab, startPosition, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserMoveSpeed, 0);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile laser = collider.gameObject.GetComponent<Projectile>();
		
		if(godMode == false && laser){
			Debug.Log("Player collided with a missile");
			health -= laser.GetDamage();
			laser.Hit();
			
			if (health <= 0){
				Die ();
			}
		}
	}
	
	void Die(){
		Destroy(this.gameObject);
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		levelManager.LoadLevel("Game Over");
	}
}
