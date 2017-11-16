using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour {
	float z;
	bool collide;
	int direction;
	int count;

	// Use this for initialization
	void Start () {
		z = 5;
		collide = false;
		direction = -1;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0,2.5f,z);
		if (collide == true) {
				direction = 1;
			} else {
				direction = 0;
			}
	
		if (z > 5) {
			direction = -1;
			collide = false;
		}
			
		if (direction == 0 || direction == -1) {
			z -= 0.1f;
		} else {
			z += 0.1f;
		}

		Debug.Log (collide);
		
	}

	private void OnCollisionEnter(Collision collision){
//		Debug.Log ("call");
		collide = true;
		count++;
	} 
}
