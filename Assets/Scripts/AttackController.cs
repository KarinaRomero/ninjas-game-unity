using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public Vector3 direction;

	Vector3 stepVector;
	Rigidbody2D rigidBody;
	PlayerContoller playerController;

	// Use this for initialization
	void Start () {

		speed = 6;
		lifeTime = 5;
		direction = new Vector3 (-1,0,0);
		//Destroy (gameObject, lifeTime);
		rigidBody = GetComponent<Rigidbody2D>();
		stepVector = speed * direction.normalized;
		playerController = GameObject.Find("Rogue_03").GetComponent<PlayerContoller>();


	}

	void FixedUpdate () {
		rigidBody.velocity = stepVector;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.name);
		if(other.tag == "shield"){
			Destroy (gameObject);
		}else if(other.tag == "rogue" ){
			if(playerController.energy >= 15 && playerController.energy <= 100){
				playerController.energy = playerController.energy - 15;
			}

		}
	}
}
