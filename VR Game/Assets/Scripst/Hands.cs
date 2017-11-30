using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour {
	public float speed = 0.1f;

	Vector3 rightPosition;
	Vector3 leftPosition;
	Vector3 startPosition;
	Vector3 upPosition;
	Vector3 yVector;

	public float counterA = 0;
	public float speed2 = 0.01f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {

		rightPosition = transform.position + transform.right;
		leftPosition = transform.position + transform.right * -1;
		startPosition = transform.position;
		upPosition = transform.forward;

//		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 hVector = Vector3.right * Input.GetAxis("Horizontal") * speed;
		Vector3 vVector = Vector3.forward * Input.GetAxis("Vertical") * speed;
		yVector= transform.up  * counterA * speed;
		Vector3 combinedVector = (hVector + vVector + yVector).normalized * speed;
		transform.position = transform.position + combinedVector;

		if (Input.GetKey (KeyCode.Q)) {
			counterA += speed2;
			//Move the Rigidbody upwards constantly at speed you define (the green arrow axis in Scene view)
//			yVector = transform.up * counterA * speed;
			if (counterA >= 1) {
				counterA = 1;
			}
		} else if (Input.GetKeyUp (KeyCode.Q)) {
			counterA = 0;
		}

		if (Input.GetKey(KeyCode.Z))
		{
			counterA -= speed2;
			//Move the Rigidbody downwards constantly at the speed you define (the green arrow axis in Scene view)
//			yVector = -transform.up *Mathf.Lerp(-1,0,counterA) * speed;
			if (counterA <= -1) {
				counterA = -1;
			}
		}else if (Input.GetKeyUp (KeyCode.Z)) {
			counterA = 0;
		}
		Debug.Log (counterA);
	}
}
