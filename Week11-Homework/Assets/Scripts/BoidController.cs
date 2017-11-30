using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour {

	public int numberofBoids = 50;
	public GameObject boidPrefab;
	public float spawnRadius =2;

	[Header("Boid Motion Variables")]
	public float maxSpeed = 0.1f;
	public float maxTurn = 0.01f;

	[Header("flocking Tuning Variables")]
	public float groupingStrength = 0.1f;
	public float spacingRadius = 1;
	public float spacingStrength = 0.1f;
	public float facingStrength = 1f;



	[Space]
	public bool drawDebug = false;

	public Transform[] boids;

	// Use this for initialization
	void Start () {
		boids = new Transform[numberofBoids];

		for (int i = 0; i < numberofBoids; ++i) {
			Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
			GameObject newBoid = Instantiate<GameObject> (boidPrefab, spawnPosition, Random.rotation);
			//pass a reference to us(the controller) tp the newly created boid
			newBoid.GetComponent<BoidBehaviour> ().controller = this;
			boids [i] = newBoid.transform;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
