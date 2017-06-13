using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySim : MonoBehaviour {

	private Rigidbody2D rb;

	public float direction; //degrees
	public float gravity;

	// Use this for initialization
	void Start () {

		rb = this.GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		float xGrav = gravity * Mathf.Cos (direction * Mathf.Deg2Rad);
		float yGrav = gravity * Mathf.Sin (direction * Mathf.Deg2Rad);

		float xVelo = rb.velocity.x + xGrav * Time.deltaTime;
		float yVelo = rb.velocity.y + yGrav * Time.deltaTime;

		rb.velocity = new Vector2 (xVelo, yVelo);
		
	}
}
