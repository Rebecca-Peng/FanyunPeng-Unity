using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Rotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[256];

		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

		for (int i = 1; i < spectrum.Length - 1; i++)
		{
			if (spectrum [i] > 1f) {
				transform.rotation = Quaternion.AngleAxis (spectrum [i] * 10, transform.up) * transform.rotation;
//				transform.rotation = Quaternion.AngleAxis (spectrum [i] * 5, transform.forward) * transform.rotation;
//				transform.rotation = Quaternion.AngleAxis (spectrum [i] * 3, transform.right) * transform.rotation;
			} else {
				transform.rotation = Quaternion.AngleAxis (spectrum [i] * 100000, transform.up) * transform.rotation;
//				transform.rotation = Quaternion.AngleAxis (spectrum [i] * 50000, transform.forward) * transform.rotation;
//				transform.rotation = Quaternion.AngleAxis (spectrum [i] * 30000, transform.right) * transform.rotation; 
			}
//			Debug.Log (orbitPath.xAxis);
		}
	}
}
