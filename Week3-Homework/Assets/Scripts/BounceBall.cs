using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour {

	public GameObject target;
	public Vector3 velocity;
	public float speed;

	public GameObject newball;
	int count;

	private Vector3 acceleration;
	private bool collide;
	private bool NewBall;

	//sound effect
//	public AudioSource[] soundEffect;

	//materials
	public Material[] materials;
	Renderer rend;

	//newShpere color
	Color[] SphereColor = {Color.red,new Color(1.0f,0.5f,0),Color.yellow,Color.green,Color.blue,Color.black,new Color(1.0f,0,1.0f)};

	void Start () {
		velocity = new Vector3 (Random.Range (-.1f, .1f), 0f, Random.Range (-.1f, .1f));

		acceleration = new Vector3 (0f, -.1f, 0f);
		NewBall = false;
		collide = false;

		rend = GetComponent<Renderer> ();
		rend.sharedMaterial = materials [0];
	}
	
	// Update is called once per frame
	void Update () {

		//movement
		this.transform.position += velocity;
		velocity *= speed;
		boundsCheck (this.transform.position,target.GetComponent<Bounds>().walls,this.transform.localScale);
		if (collide) {
			GenerateBall ();
			BallMovement (newball);
			print (count);
			rend.sharedMaterial = materials [count];
			if (count == 6)
			{
				count = 0;
			}
		}


		gravitationMovement ();	
	}
	void boundsCheck(Vector3 checkFrom, Vector3 checkAgainst, Vector3 size)
	{
		if(checkFrom.x + size.x/2f >= checkAgainst.x/2f)
		{
			
			velocity.x *= -1f;
			collide = true;

		}
		if(checkFrom.x - size.x/2f <= -checkAgainst.x/2f)
		{
			velocity.x *= -1f;
			collide = true;
		}
		//y
		if(checkFrom.y + size.y/2f >= checkAgainst.y/2f)
		{
			velocity.y *= -1f;
			collide = true;
		}
		if(checkFrom.y - size.y/2f <= -checkAgainst.y/2f)
		{
			velocity.y *= -1f;
			collide = true;
		}
		//z
		if(checkFrom.z + size.z/2f >= checkAgainst.z/2f)
		{
			velocity.z *= -1f;
			collide = true;
		}
		if(checkFrom.z - size.z/2f <= -checkAgainst.z/2f)
		{
			velocity.z *= -1f;
			collide = true;
		}
	}

	void GenerateBall()
	{
		if (collide) {
			count++;
			newball = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			newball.transform.position = this.transform.position;
			newball.transform.localScale = this.transform.localScale / 2f;
			newball.GetComponent<Renderer> ().material.color = SphereColor[count]; 
			collide = false;
			NewBall = true;
		}
	}

	void BallMovement(GameObject Ball)
	{
			transform.position += velocity;
			print (Ball.transform.position);
			boundsCheck (transform.position, target.GetComponent<Bounds> ().walls, transform.localScale);
	}
		
	void gravitationMovement()
	{
		velocity = velocity + acceleration * Time.deltaTime;
	}
		

//	void CreatePrimitive1()
//	{
//		if(Input.GetKeyDown(KeyCode.A)){
//			newball = GameObject.CreatePrimitive (PrimitiveType.Sphere);
////			newball.transform.position = new Vector3 (-10,5,5);
//			print ("1");
//		}
//	}
}
