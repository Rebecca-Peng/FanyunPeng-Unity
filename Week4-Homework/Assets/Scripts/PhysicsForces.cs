using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsForces : MonoBehaviour {
	
	public Vector3 forceVector;
	public VectorDrawer forceVectorSource;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update () {
		OnMouseDown ();
	}

	void OnMouseDown()
	{
		if(Input.GetMouseButtonDown(0)){
			Debug.Log ("Hit");
			forceVector = forceVectorSource.vector;
			rb.AddForce (forceVector);
		}
	}
}
