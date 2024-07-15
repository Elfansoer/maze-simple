using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour {
	public int speed;

	Vector3 direction;
	Rigidbody body;

	// Use this for initialization
	void Awake() {
		direction = new Vector3(0,0,0);
		body = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		direction.x = Input.GetAxisRaw("Horizontal");
		direction.z = Input.GetAxisRaw("Vertical");
		direction.Normalize();
	}

	void FixedUpdate() {
		body.AddForce(direction * speed * Time.fixedDeltaTime);
	}
}
