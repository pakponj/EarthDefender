using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour {

	public int health;
	public Text healthText;
	public float speed;

	// Use this for initialization
	void Start () {
		health = 10;
		speed = 1f;
	}

	void Update() {
		gameObject.transform.position += speed * Time.deltaTime * Vector3.left;
	}

}
