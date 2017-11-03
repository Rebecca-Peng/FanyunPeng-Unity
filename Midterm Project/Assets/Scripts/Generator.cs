using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	public GameObject objectToInstatiate;
	public int numberToInstantiate = 500;
	private int count = 0;
	public AnimationCurve curve = AnimationCurve.Linear (0,0,1,1);

	// Use this for initialization
	void Start () {
		for (int i = 0; i < numberToInstantiate; ++i) {
//			Vector2 randomInCircle = Random.insideUnitCircle;
			Vector3 randomInSphere = Random.insideUnitSphere;
			Vector3 instantiateAtPosition = objectToInstatiate.transform.position +
				objectToInstatiate.transform.rotation * (new Vector3 (randomInSphere.x, randomInSphere.y, randomInSphere.z) * 20f);
			Quaternion instantiateWithRotation = objectToInstatiate.transform.rotation;

			GameObject spawnedObject = Instantiate<GameObject> (objectToInstatiate, 
				                           instantiateAtPosition, 
				                           instantiateWithRotation,
				                           transform
			                           );
			Vector3 newScale = new Vector3(1,curve.Evaluate(1-randomInSphere.magnitude)*10f,1);
			spawnedObject.transform.localScale =newScale;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEveryFrame () {
		if (count > numberToInstantiate)
			return;
		Debug.LogWarning(count);
		Instantiate<GameObject> (objectToInstatiate, objectToInstatiate.transform.position + objectToInstatiate.transform.forward * Random.value * 10, Random.rotation);
		//			objectToInstatiate.transform);//set this as aparent of the newly instantiateted clone
		count ++;
	}
}
