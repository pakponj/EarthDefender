using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

	public float duration;
	public GameObject player;
	public SpriteRenderer sr;

	void OnEnable() {
		duration = 5f;
	}

	// Use this for initialization
	void Start () {
		duration = 5f;
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = (3.75f * Vector3.right) + player.transform.position;
		float randomAlpha = Random.Range (0.25f, 0.75f);
		sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, randomAlpha);
		duration -= Time.deltaTime;
		if (duration <= 0) {
			player.GetComponent<Player> ().isBeaming = false;
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			collider.gameObject.SetActive (false);
		}
	}
}
