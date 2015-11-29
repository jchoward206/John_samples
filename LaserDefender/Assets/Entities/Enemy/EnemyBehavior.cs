using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 150f;
	public int scoreValue = 150;
	public GameObject laserPrefab;
	public float laserMoveSpeed = 0f;
	public float laserRateOfFire = 0.2f;
	public float shotsPerSecond = 0f;
	public AudioClip damagedSFX;
	public AudioClip destroyedSFX;
	public GameObject explosionFX;
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		// necessary to find the ScoreKeeper b/c the enemies are being created dynamically 
		scoreKeeper = GameObject.Find("Points").GetComponent<ScoreKeeper>();	
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile playerLaser = collider.gameObject.GetComponent<Projectile>();
		
		if(playerLaser){
			health -= playerLaser.GetDamage();
			playerLaser.Hit();
			//play a particle FX on damage
			GameObject.Instantiate(explosionFX, this.transform.position, Quaternion.identity);
			
			if (health <= 0){
				Die ();
			} else AudioSource.PlayClipAtPoint(damagedSFX, transform.position, 1.0f);
		}
	}
	
	void Update(){
		// fancy function for creating a tunable rough probability
		float probabilty = shotsPerSecond * Time.deltaTime;
		if(Random.value < probabilty){
			FireLaser();
		}
	}
	
	void FireLaser(){
		GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0,- laserMoveSpeed, 0);
	}
	
	void Die(){
		Destroy(this.gameObject);
		AudioSource.PlayClipAtPoint(destroyedSFX, transform.position, 1.0f);
		Debug.Log(scoreValue.ToString());
		scoreKeeper.Score(scoreValue);
	}
}
