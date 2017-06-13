using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autorotate : MonoBehaviour {

	private Vector3 rot;

	// Use this for initialization
	void Start () {

		rot = this.transform.eulerAngles;
		
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.eulerAngles = rot;
		
	}
}
