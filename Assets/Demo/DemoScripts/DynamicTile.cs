using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTile : MonoBehaviour {
	float radius = 16f;
	float min = -6f;
	float max = 11f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// check colliders
		Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
		foreach( Collider c in colliders ) {
			GameObject parent = c.gameObject;
			if ( parent.tag!="DynamicWall" ) continue;

			// get distance
			float distance = Vector3.Distance(transform.position, parent.transform.position);
			float height = (1-distance/radius)*(max-min) + min;

			Vector3 pos = parent.transform.position;
			pos.y = height;
			parent.transform.position = pos;
		}
	}
}
