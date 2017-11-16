using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R)) {
			
//			transform.rotation = Quaternion.AngleAxis (45, Vector3.up) * transform.rotation;
			transform.Rotate(Time.time,Time.time,Time.time);
		}
		
	}
}
