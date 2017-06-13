using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONUTS : MonoBehaviour {

	private GameObject world;
	private GameObject gameController;
	private GameObject player;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	public float minDist;

	// Use this for initialization
	void Start () {

		world = GameObject.FindGameObjectWithTag ("World");
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		player = GameObject.FindGameObjectWithTag ("Player");

		this.transform.parent = world.transform;
		Relocate ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag == "Player") {

			gameController.GetComponent<Stats> ().donutCount++;
			Relocate ();

		}

	}

	void Relocate () {

		Vector2 newLoc = ChooseDestination ();
		transform.position = newLoc;
		this.transform.parent = world.transform;

	}

	Vector2 ChooseDestination () {

		this.transform.parent = null;

		Debug.Log ("NEW DONUT:");

		float xInit = Random.Range (minX, maxX);
		float yInit = Random.Range (minY, maxY);

		Debug.Log ("Initial pos: (" + xInit.ToString () + ", " + yInit.ToString () + ")");

		float r = Mathf.Sqrt (xInit * xInit + yInit * yInit);
		float theta = Mathf.Atan (yInit / xInit) * Mathf.Rad2Deg;
		if (xInit <= 0)
			theta += 180f;
		float worldRot = world.transform.eulerAngles.z;

		Debug.Log ("r = " + r.ToString ());
		Debug.Log ("Theta = " + theta.ToString ());
		Debug.Log ("World rotation = " + worldRot.ToString ());

		theta += worldRot;

		Debug.Log ("New theta = " + theta.ToString ());

		float x = r * Mathf.Cos (theta * Mathf.Deg2Rad);
		float y = r * Mathf.Sin (theta * Mathf.Deg2Rad);

		Debug.Log ("New pos: (" + x.ToString () + ", " + y.ToString () + ")");

		Vector2 pos = new Vector2 (x, y);
		Vector2 playerPos = new Vector2 (player.transform.position.x, player.transform.position.y);
		Vector2 diff = playerPos - pos;
		float d = Mathf.Sqrt (diff.x * diff.x + diff.y * diff.y);

		if (d > minDist)
			return pos;
		else 
			return ChooseDestination ();

	}

}
