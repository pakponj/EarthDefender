using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour {

	public SpriteRenderer sr;

	public float speed;

	// Use this for initialization
	void Start () {
		speed = 5f;
		sr = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (sr.isVisible) {
			float randomAlpha = Random.Range (0.25f, 0.75f);
			sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, randomAlpha);
			gameObject.transform.position += speed * Time.deltaTime * Vector3.right;
		} else {
			gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			collider.gameObject.SetActive (false);
			gameObject.SetActive (false);
		} else if (collider.gameObject.tag == "Boss") {
			int health = collider.gameObject.GetComponent<Boss> ().health--;
			if (health == 0) {
				SceneManager.LoadScene ("Win");
			}
		}
	}
}
