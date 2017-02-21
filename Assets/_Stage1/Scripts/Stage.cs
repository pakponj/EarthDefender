using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour {

	public Camera mainCam;
	public Player player;

	public float xMax;
	public float yMax;

	public float offset;

	public List<GameObject> lasers;
	public GameObject beam;

	public GameObject laserPrefab;
	public GameObject beamPrefab;
	public GameObject[] enemiesPrefab;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main;
		player = GameObject.FindWithTag ("Player").GetComponent<Player>();
		player.stage = this;

		Vector3 middle = mainCam.ViewportToWorldPoint( new Vector3 (1f, 1f, 10f) );
		offset = 1f;
		xMax = middle.x - offset;
		yMax = middle.y - offset;
//		Debug.Log (xMax.ToString ());
//		Debug.Log (yMax.ToString ());

		AddLasers ();
		GetBeam ();
	}
	
	// Update is called once per frame
	void Update () {
		player.Respawn ();
	}


	void AddLasers() {
		GameObject laser;
		for (int i = 0; i < 25; i++) {
//			print ("Making lasers "+i);
			laser = Instantiate (laserPrefab);
			laser.SetActive (false);
			lasers.Add (laser);
		}
	}

	public GameObject GetLaser() {
		foreach (var laser in lasers) {
			if (!laser.activeInHierarchy) {
				return laser;
			}
		}
		return null;
	}

	public GameObject GetBeam() {
		if (!beam) {
			beam = Instantiate (beamPrefab);
			beam.SetActive (false);
			beam.GetComponent<Beam> ().player = player.gameObject;
		}
		return beam;
	}
}
