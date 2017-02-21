using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float speed;
	public float rotatingSpeed;

	// Use this for initialization
	void Start () {
		speed = Random.Range (1.5f, 6.5f);
		rotatingSpeed = Random.Range (10f, 20f);
	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate (rotatingSpeed * Time.deltaTime * Vector3.forward);
		gameObject.transform.position += speed * Time.deltaTime * Vector3.left;
	}
}
