using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidBehaviour : MonoBehaviour {

	[HideInInspector]
	public BoidController controller;

	private Vector3 groupingVector;//cohesion
	private Vector3 facingVector;//separation
	private Vector3 spacingVector;//alignment

	private Vector3 currentVelocity;


	public Material[] materials;
	Renderer rend;

	private int count;

	// Use this for initialization
	void Start () {
		currentVelocity = transform.forward * controller.maxSpeed;
		transform.position += currentVelocity;

		rend = GetComponent<Renderer> ();
		rend.sharedMaterial = materials [0];
	}
	
	// Update is called once per frame
	void Update () {


		if (count >= materials.Length) {
			count = 0;
		}
		rend.sharedMaterial = materials [count];


		Vector3 desiredVelocity = Vector3.zero;
		groupingVector = Vector3.zero;
		spacingVector = Vector3.zero;
		facingVector = Vector3.zero;

		int nearFishCount = 1;

		for (int i = 0; i < controller.boids.Length; ++i) {

			Transform target = controller.boids [i];
			if (target == transform)
				continue;

			Vector3 tempGrouping = target.position - transform.position ;
			groupingVector +=tempGrouping * controller.groupingStrength;

			float distanceToTartent = groupingVector.magnitude;
			if (distanceToTartent < controller.spacingRadius) {
				count++;
				nearFishCount++;

				Vector3 tempSpacing = tempGrouping * -1;
				spacingVector += (tempSpacing / distanceToTartent)*controller.spacingStrength;

				//alignment
				facingVector += target.forward * controller.facingStrength;

			}

		}

		groupingVector =  groupingVector / controller.boids.Length;
		Debug.Log (groupingVector);
		spacingVector = spacingVector / nearFishCount;
		Debug.Log (spacingVector);
		facingVector = facingVector / nearFishCount;
		Debug.Log (facingVector);

		desiredVelocity =  groupingVector + spacingVector + facingVector;

		//clamp desired velocity speed
		desiredVelocity = Vector3.ClampMagnitude (desiredVelocity,controller.maxSpeed);
		if (controller.drawDebug) {
			Debug.DrawRay (transform.position, desiredVelocity, Color.red, 0.1f);
		}


		currentVelocity = Vector3.Lerp (currentVelocity,desiredVelocity,controller.maxTurn);

		transform.rotation = Quaternion.LookRotation ( desiredVelocity, new Vector3(Random.value,0, Random.value));

		transform.position += currentVelocity;	
	}
}
