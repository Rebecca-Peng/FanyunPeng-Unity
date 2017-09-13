using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour {
	
	Vector3 temp = new Vector3(0,0,0);
	float a = 0.5f;
	int direction = 1;
	int direction2 = 1;
	[Range(0,2.0f)]
	public float BlinkSpeed = 0.9f;

	[Range(0,1)]
	public float r;
	[Range(0,1)]
	public float g;
	[Range(0,1)]
	public float b;

	[Range(0,2.0f)]
	public float gravity;
	bool Against = false;


	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.SetColor ("_Color", new Color(r,g,b));
		transform.position = new Vector3 (Random.Range(-5.0f,5.0f), Random.Range(5.0f,20.0f), Random.Range(-5.0f,5.0f));
//		transform.position = new Vector3(0,10,0);
		transform.localScale = temp;
		BlinkSpeed = Random.Range (0.5f, 0.9f);
		gravity = Random.Range (5.0f, 9.8f);
		r = Random.Range (0, 1.0f);
		g = Random.Range (0, 1.0f);
		b = Random.Range (0, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

		//Blink
		temp = transform.localScale;
		a += Time.deltaTime * BlinkSpeed * direction;
		temp = new Vector3 (a, a, a);
		transform.localScale = temp;

		if (a >= 1.0f || a<=0.5f) {
			direction *= -1;
		}

		//Color
		GetComponent<Renderer>().material.SetColor ("_Color", new Color(r,g,b));

		//Movement
		transform.position -= new Vector3(0.0f , 0.1f * gravity * direction2, 0.0f) * Time.deltaTime;
		if (transform.position.y <= 0) {
			Against = true;
			direction2 = -1;
			gravity = 1;
		} 
		if (Against) {
			gravity -= 0.1f * Time.deltaTime;
		}
		if (gravity <= 0) {
			Against = false;
			direction2 = 1;
			gravity = 9.8f;
		}

		//Rotate
//		transform.Rotate(new Vector3(15,30,45) * Time.deltaTime);

	}
}
