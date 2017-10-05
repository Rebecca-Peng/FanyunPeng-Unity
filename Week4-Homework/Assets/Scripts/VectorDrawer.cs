using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDrawer : MonoBehaviour {

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;

	//power
	private float dist;
	public Vector3 vector;

	// Use this for initialization
	void Start () {

		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.widthMultiplier = 0.2f;

		// A simple 2 color gradient with a fixed alpha of 1.0f.
		float alpha = 1.0f;
		Gradient gradient = new Gradient();
		gradient.SetKeys(
			new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
			new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
		);
		lineRenderer.colorGradient = gradient;
	}

	// Update is called once per frame
	void Update () {
		LineRenderer lineRenderer = GetComponent<LineRenderer>();
		dist = Vector3.Distance (new Vector3(0,0,0),new Vector3(Input.mousePosition.x,Input.mousePosition.y,0));
		//		Debug.Log (Input.mousePosition.x/dist);
		lineRenderer.SetPosition (0,new Vector3(Input.mousePosition.x -380,Input.mousePosition.y-180,0) * 0.05f);
//		lineRenderer.SetPosition (0,Input.mousePosition * 0.01f);
		vector = new Vector3 (Input.mousePosition.x -380,Input.mousePosition.y-180,0) * 0.01f;
//		vector = Input.mousePosition * 0.001f;
//		Debug.Log (Input.mousePosition);

	}
		

}
