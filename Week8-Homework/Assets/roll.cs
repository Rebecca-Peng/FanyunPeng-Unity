using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roll : MonoBehaviour {
	float thrust;
	public Rigidbody rb;
	bool collide = false;

	// Use this for initialization
	void Start () {
//		rb = GetComponent<Rigidbody>();
		thrust = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (collide) {
			rb.AddForce (transform.forward * thrust);
		}	
	}
	private void OnCollisionEnter(Collision collision){
		Debug.Log ("call");
		collide = true;
	} 
}
