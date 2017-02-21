using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = Random.Range (1.5f, 6.5f);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position += speed * Time.deltaTime * Vector3.left;
	}
}
