using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int health;

	public float hIn;
	public float vIn;

	public Vector3 move;

	public float speed;

	public Stage stage;

	public int laserNum;
	public int laserShot;
	public int laserBeam;

	public float rechargeTime;
	public float rechargePerShot;
	public float laserCooldown;
	public float beamCooldown;
	public float vulnerableTime;

	public bool isBeaming;
	public bool isBlinking;
	public Text energyText;
	public Text healthText;

	public SpriteRenderer sr;

	public float respawnTime;

	// Use this for initialization
	void Start () {
		health = 3;

		hIn = 0f;
		vIn = 0f;

		speed = 5f;

		move = Vector3.zero;

//		stage = stageObj.GetComponent<Stage> ();

		laserNum = 25;
		laserShot = 1;
		laserBeam = 10;
		updateText ();

		rechargeTime = 0f;
		rechargePerShot = 1.5f;
		laserCooldown = 0.5f;
		beamCooldown = 10f;
		vulnerableTime = 0f;
		respawnTime = 3f;

		sr = gameObject.GetComponent<SpriteRenderer> ();

		isBlinking = false;
	}
	
	// Update is called once per frame
	void Update () {
		movePlayer ();
		Fire ();
		Beam ();
		Recharge ();
		Blink ();
	}

	void movePlayer() {
		hIn = Input.GetAxis ("Horizontal");
		vIn = Input.GetAxis ("Vertical");
		
		move.x = Mathf.Clamp (gameObject.transform.position.x + hIn * Time.deltaTime * speed, -stage.xMax, stage.xMax);
		move.y = Mathf.Clamp (gameObject.transform.position.y + vIn * Time.deltaTime * speed, -stage.yMax, stage.yMax);
		
		gameObject.transform.position = move;
		
	}

	void Fire() {
		if (laserNum >= laserShot & laserCooldown >= 0.4f & !isBeaming) {
			if (Input.GetKeyDown (KeyCode.Z)) {
				GameObject laser = stage.GetLaser ();
				if (!laser) {
					laser = Instantiate (laser);
					laser.SetActive (false);
					stage.lasers.Add (laser);
				}
				laserNum--;
				updateText ();
				laserCooldown = 0f;
				laser.transform.position = ( 1.25f * Vector3.right ) + gameObject.transform.position ;
				laser.SetActive (true);
			}
		}
	}

	void Beam() {
		if (laserNum >= laserBeam & beamCooldown >= 10f) {
			if (Input.GetKeyDown (KeyCode.X)) {
//				print ("Fire beam");
				isBeaming = true;
				GameObject beam = stage.GetBeam ();
				laserNum -= 15;
				updateText ();
				beamCooldown = 0f;
				beam.transform.position = (1.25f * Vector3.right) + gameObject.transform.position;
				beam.SetActive (true);
			}
		}
	}

	void Recharge() {
		rechargeTime += Time.deltaTime;
		laserCooldown += Time.deltaTime;
		beamCooldown += Time.deltaTime;
		if (rechargeTime > rechargePerShot & laserNum < 25) {
			laserNum++;
			updateText ();
			rechargeTime = 0f;
		}
	}

	void updateText() {
		energyText.text = laserNum.ToString ();
		healthText.text = health.ToString ();	
	}

	void Blink() {
		if (isBlinking) {
			vulnerableTime -= Time.deltaTime;
			if (vulnerableTime <= 0) {
				isBlinking = false;
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f );
			} else {
				sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, Random.Range(0.25f,0.75f) );
			}
		}
	}

	public void Respawn() {
		if (health == 0) {
			gameObject.SetActive (false);
			respawnTime -= Time.deltaTime;
			if (respawnTime <= 0f) {
				gameObject.SetActive (true);
				health = 3;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (vulnerableTime <= 0) {
			if (collider.gameObject.tag == "Enemy") {
				health--;
				updateText ();
				isBlinking = true;
				vulnerableTime = 2f;
			}
		}
	}
}
