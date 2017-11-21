using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	Camera cam;
	public GameObject particle;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray0 = cam.ScreenPointToRay(new Vector3(200, 200, 0));
		Debug.DrawRay(ray0.origin, ray0.direction * 10, Color.yellow);

		if (Input.GetButtonDown("Fire1"))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray))
				Instantiate(particle, transform.position, transform.rotation);
		}
	}
}
