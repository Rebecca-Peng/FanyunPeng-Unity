using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	public Color colorA = Color.white;
	public Color colorB;

	private Light light;

	int count;

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		float[] spectrum = new float[256];
		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
		for (int i = 1; i < spectrum.Length - 1; i++) {
			if (spectrum [i] < 0.001f) {
//				light.color = Color.Lerp (colorA, colorB,spectrum [i]);
			}
			else if (spectrum [i] >= 0.1f) {
				count++;
				light.spotAngle =100 + spectrum [i];
			}
			if (count == 0) {
				light.color = colorA;
				light.spotAngle = 110;
			}else 
			{
				if(count % 2 == 0) {
				light.color = colorA;

			} else {
				light.color = colorB;
			}
			}
		}
		
	}
}
