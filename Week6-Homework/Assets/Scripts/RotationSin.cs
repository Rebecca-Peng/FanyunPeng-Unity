using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSin : MonoBehaviour {

	float step = 1f;
	float speed = 0.0f;

	private float waitingTime = 3.0f;
	private float timer = 0.0f;

	private Light light;

	public Color colorA = Color.white;
	public Color colorB = Color.black;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
		speed = 0.1f;
	}

	// Update is called once per frame
	void Update () {
		step += speed;
		timer += Time.deltaTime;
//		for (int i = 1; i <= 3; i++) {
//			if (timer > 0.5 * i && timer < i) {
//				light.color = Color.Lerp (colorA, colorB, Time.time);
//			} else {
//				light.color = Color.Lerp (colorB, colorA, Time.time);
//			}
//		}
		//		transform.Rotate (0,Mathf.Cos(Time.time),0);
		if (timer < waitingTime) {
			transform.Rotate (0, Mathf.Sin (step), 0);
		} else {
			transform.Rotate (0, 0, 0);
		}
	}
}
