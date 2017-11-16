using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour {

	float axis = 0;
	public float jumpForce = 1;
	public float speed = 0.1f;

	bool canJump = true;

	Vector3 rightPosition;
	Vector3 leftPosition;
	Vector3 startPosition;
	Vector3 upPosition;

	Rigidbody rb;

	// Use this for initialization
	void Start () {

		rightPosition = transform.position + transform.right;
		leftPosition = transform.position + transform.right * -1;
		startPosition = transform.position;
		upPosition = transform.up;

		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 hVector = Vector3.right * Input.GetAxis("Horizontal") * speed;
		Vector3 vVector = Vector3.forward * Input.GetAxis("Vertical") * speed;

		Vector3 combinedVector = (hVector + vVector).normalized * speed;
		Debug.DrawRay(startPosition, combinedVector, Color.red, 0.5f);
		Vector3 raycastVector = combinedVector;

		if(Input.GetButton("Jump") && canJump){
			rb.AddForce (Vector3.up * jumpForce);
			canJump = false;
		}
		rb.AddForce(combinedVector);
		transform.rotation = Quaternion.LookRotation (combinedVector);

		RaycastHit whatWeHit;

		Debug.DrawRay (transform.position,raycastVector ,Color.blue);
		if (Physics.Raycast (transform.position, raycastVector, out whatWeHit, 5f)) {

			Debug.LogWarning ("Raycast hit " + whatWeHit.transform.gameObject);

			whatWeHit.transform.Rotate (Vector3.up,1);
		}
}

	private void OnCollisionEnter(Collision collision){
		Debug.Log ("Collided with " + collision.gameObject.tag);

		if (collision.gameObject.CompareTag ("s")) {
			canJump = true;
		}
	}
}