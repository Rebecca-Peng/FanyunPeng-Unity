using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks : MonoBehaviour {

	public Transform firework;
	private float waitingTime = 3.0f;
	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		firework.GetComponent<ParticleSystem> ().enableEmission = false;
	}

	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > waitingTime) {
			print ("test1");
			firework.GetComponent<ParticleSystem> ().enableEmission = true;
			print ("test2");
		}
		if (timer > waitingTime + 3.0f) {
			firework.GetComponent<ParticleSystem> ().enableEmission = false;
		}
	}
}
