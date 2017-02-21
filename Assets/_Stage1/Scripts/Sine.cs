using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine : MonoBehaviour {

	public float speed;
	public float x;
	public float y;

	// Use this for initialization
	void Start () {
		speed = 2.5f;
		x = gameObject.transform.position.x;
		y = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		x += speed * Time.deltaTime * -1;
		y += 0.25f * Mathf.Sin ( x * 90 * Mathf.Deg2Rad );
		Vector2 position = new Vector2 (x, y);
		gameObject.transform.position = position;
	}
}
