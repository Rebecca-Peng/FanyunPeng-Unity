using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour {
	public GameObject objectToInstantiate;
	public int numberToInstantiate = 500;
	public Gradient gradient;

	public float maxSpeed = 10;
	Rigidbody[] spawnedObjects;

	int count = 0;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < numberToInstantiate; ++i)
		{
			Vector3 SpawnPos = transform.position+Random.insideUnitSphere*10f;
			Quaternion SpawnRot = transform.rotation;

			Instantiate<GameObject>(objectToInstantiate,SpawnPos,SpawnRot,transform);


		}

		spawnedObjects = GetComponentsInChildren<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[256];
		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
		for (int i = 1; i < spectrum.Length - 1; i++) {

			if (spectrum [i] < 0.001f) {
//				transform.Rotate (spectrum [i] * 100, 0, 0);
				transform.position = new Vector3(spectrum [i],0,0);
			} else if (spectrum [i] < 0.005f && spectrum [i] >= 0.001f) {
			} else if (spectrum [i] < 0.01f && spectrum [i] >= 0.005f) {
			} else if (spectrum [i] < 0.5f && spectrum [i] >= 0.01f) {
				for (int t = 0; t < spawnedObjects.Length; ++t) {
					spawnedObjects[t].AddForce(transform.position-spawnedObjects[t].transform.position);
				}

			} else if (spectrum [i] < 0.1f && spectrum [i] >= 0.5f) {

			} else {
				for (int t = 0; t < spawnedObjects.Length; ++t) {
					count++;
					spawnedObjects [t].mass = spectrum [i] * 0.5f;
//					transform.position = new Vector3(Mathf.Log(spectrum [i]),0,0);
				}
				for (int t = 0; t < spawnedObjects.Length; ++t) {
					spawnedObjects[t].AddForce(new Vector3(spectrum [i]*10f,spectrum [i]*10f,spectrum [i]*10f)+spawnedObjects[t].transform.position-transform.position);
					numberToInstantiate = (int)spectrum [i] * 100;
				}
				Debug.Log (count);
			}
			count = 0;
		}
		for (int t = 0; t < spawnedObjects.Length; ++t) {
			float speed = Mathf.Clamp01(spawnedObjects[t].velocity.sqrMagnitude);
			Color newColor = gradient.Evaluate(speed/maxSpeed);
			spawnedObjects[t].transform.GetComponent<MeshRenderer>().material.SetColor("_Color",newColor);
		}
		
	}
}
