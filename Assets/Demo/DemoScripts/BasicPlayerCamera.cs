using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerCamera : MonoBehaviour {
	public GameObject playerCamera;
	Vector3 relativePos;

	// Use this for initialization
	void Start() {
		// get pos
		relativePos = playerCamera.transform.position-transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		playerCamera.transform.position = transform.position + relativePos;
	}
}
