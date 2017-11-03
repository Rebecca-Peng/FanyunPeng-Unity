using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour {
	
	int count0;
	int count1;
	int count2;
	int count3;
	int count4;
	int count5;

	// Use this for initialization
	void Start () {
		
		
	}

	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[256];
		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
		for (int i = 1; i < spectrum.Length - 1; i++) {

			if (spectrum [i] < 0.001f) {
				count0++;
				transform.position += new Vector3 (spectrum [i],0,0);
//				transform.position = new Vector3 (Mathf.Log(spectrum [i]), 0,0);
				transform.Rotate (spectrum [i], 0, 0);
			} else if (spectrum [i] < 0.005f && spectrum [i] >= 0.001f) {
				count1++;
//				transform.position += new Vector3 (-1*spectrum [i],0,0);
				transform.position = new Vector3 (Mathf.Log(i), 0,0);
				transform.Rotate (0,spectrum [i], 0);
			} else if (spectrum [i] < 0.01f && spectrum [i] >= 0.005f) {
				count2++;
				transform.position = new Vector3 (0, spectrum [i],0);
				transform.Rotate (0,0,spectrum [i]);
			} else if (spectrum [i] < 0.5f && spectrum [i] >= 0.01f) {
				transform.position = new Vector3 (0, Mathf.Log(i),0);
				transform.Rotate (0,spectrum [i],spectrum [i]);
				count3++;
			} else if (spectrum [i] < 0.1f && spectrum [i] >= 0.5f) {
				transform.Rotate (spectrum [i] , 0, spectrum [i] );
				count4++;
			} else {
				transform.Rotate (spectrum [i] , spectrum [i] , 0);
				count5++;
			}
		}
	}
}
