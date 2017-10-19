using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screens : MonoBehaviour {
	
	public Material[] materials;
	Renderer rend;
	int count = 3;
	private float waitingTime = 1.0f;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rend.sharedMaterial = materials [count];
		timer += Time.deltaTime;
		if (timer > waitingTime) {
			timer = 0f;
			count--;
		}
		if (count <= 0) {
			count = 0;
		}
	}
}
