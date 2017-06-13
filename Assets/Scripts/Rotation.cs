using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	public float rotSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float newRot = 0f;

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow))
			newRot += rotSpeed;
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))
			newRot -= rotSpeed;

		transform.eulerAngles = new Vector3 (0.0f, 0.0f, transform.eulerAngles.z + newRot);
		
	}
}
