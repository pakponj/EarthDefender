using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Earth : MonoBehaviour {

	public int health;
	public Text healthText;

	void Start () {
		health = 5;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Enemy") {
			health--;
			healthText.text = health.ToString ();
			collider.gameObject.SetActive (false);
		} else if (collider.gameObject.tag == "Boss") {
			health = 0;
		}
		if (health == 0) {
			SceneManager.LoadScene ("Lose");
		}
	}

}
