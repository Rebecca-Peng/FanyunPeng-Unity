using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Box : MonoBehaviour {

	Vector3[] directions = { new Vector3 (1, 0, 0), new Vector3 (0, 1, 0), new Vector3 (0, 0, 1), new Vector3 (1, 1, 0), new Vector3 (1, 0, 1), new Vector3 (0, 1, 1)};
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
//				transform.Rotate (Mathf.Log (spectrum [i]*10), 0, 0);
				transform.Rotate (spectrum [i]*100, 0, 0);
			} else if (spectrum [i] < 0.005f && spectrum [i] >= 0.001f) {
				count1++;
				transform.Rotate (0,spectrum [i]*10, 0);
//				transform.Rotate (0, Mathf.Log (spectrum [i]),0);
			}else if (spectrum [i] < 0.01f && spectrum [i] >= 0.005f) {
				count2++;
//				transform.Rotate (0,0, Mathf.Log (spectrum [i]));
				transform.Rotate (0,0,spectrum [i]*10);
			}
			else if (spectrum [i] < 0.5f && spectrum [i] >= 0.01f) {
				transform.Rotate (0,spectrum [i],spectrum [i]);
				count3++;
			}else if (spectrum [i] < 0.1f && spectrum [i] >= 0.5f) {
				transform.Rotate (spectrum [i]*90,0,spectrum [i]*90);
				count4++;
			} 
			else {
				transform.Rotate (spectrum [i]*90,spectrum [i]*90,0);
				count5++;
			}

			float num = Random.Range (0,3);
//			Debug.Log (num);
			Debug.Log ("count0: "+count0+"   count1: "+count1+"   count2: "+count2+"   count3: "+count3+"   count4: "+count4+"   count5: "+count5);
//			transform.Rotate(spectrum [i]*1f,spectrum [i]*1f,spectrum [i]*1f);
		}
			
		
	}
}
