using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

	float step = 1f;
	float speed = 0.0f;

	private float waitingTime = 3.0f;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		speed = 0.1f;

	}
	
	// Update is called once per frame
	void Update () {
		step += speed;
		timer += Time.deltaTime;
		//		transform.Rotate (0,Mathf.Cos(Time.time),0);
//
//		if (timer > waitingTime) {
//			transform.Rotate (0,0,0);
//		}
		if (timer < waitingTime) {
			transform.Rotate (0, Mathf.Cos (step), 0);
		} else {
			transform.Rotate (0,0,0);
		}
	}
}
