using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUp : MonoBehaviour {
	public GameObject hands;
	public GameObject trees;

	Vector3 newPosition = new Vector3(-1,1,0);
	Vector3 newPosition2;
	float x = 0;
	float distance = 1.0f;
	float distance2 = 1.0f;
	bool touch;
	bool onTree;

	// Use this for initialization
	void Start () {
		touch = false;
		onTree = false;
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance(hands.transform.position, transform.position);
		float distTree = Vector3.Distance(trees.transform.position, transform.position);
		newPosition2 = new Vector3(x,1,0);
		if ( Mathf.Abs (dist) <= distance) {
			touch = true;
		}
		if (touch) {
			transform.position = hands.transform.position + newPosition;
		}

		if (Mathf.Abs (distTree) <= distance2) {
			onTree = true;
			touch = false;
			x = Random.Range (-2,2);
		}
		if (onTree) {
			transform.position = trees.transform.position + newPosition2;
		}
		Debug.Log (x);
//		Debug.Log ("Dist:"+ distTree + ";" + onTree);
	}
}
