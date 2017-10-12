using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(AudioSource))]
public class OrbitMotion : MonoBehaviour {

	public Transform orbitingObject;
//	public Transform orbitingObject2;
	public Ellipse orbitPath;

	[Range(0f,1f)]
	public float orbitProgress = 0f;
	public float orbitPeriod = 3f;
	public bool orbitActive = true;
	// Use this for initialization
	void Start () {
		if (orbitingObject == null) {
			orbitActive = false;
			return;
		}
		SetOrbitingObjectPosition ();
		StartCoroutine (AnimateOribt());

	}

	void SetOrbitingObjectPosition(){
		Vector2 orbitPos = orbitPath.Evaluate (orbitProgress);
		orbitingObject.localPosition = new Vector3 (orbitPos.x,0,orbitPos.y);
	}

	void Update()
	{
		float[] spectrum = new float[256];

		AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

		for (int i = 1; i < spectrum.Length - 1; i++)
		{
			if (spectrum [i] > 1f) {
				orbitPath.xAxis = spectrum [i] +10;
				orbitPath.yAxis = spectrum [i] +10;
			} else {
				orbitPath.xAxis = spectrum [i] * 5000 + 10;
				orbitPath.yAxis = spectrum [i] * 5000 + 10fluorescence;
			}
			Debug.Log (orbitPath.xAxis);
		}


	}

	IEnumerator AnimateOribt(){
		if (orbitPeriod < 0.1f) {
			orbitPeriod = 0.1f;
		}
		float orbitSpeed = 1f / orbitPeriod;
		while (orbitActive) {
			orbitProgress += Time.deltaTime * orbitSpeed;
			orbitProgress %= 1f;
			SetOrbitingObjectPosition ();
			yield return null;
		}
	}
}
