using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour {

	public float speed;
	public float lifeTime;
	public Vector3 direction;

	Vector3 stepVector;
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		speed = 6;
		lifeTime = 2;
		Destroy (gameObject, lifeTime);
		rigidBody = GetComponent<Rigidbody2D>();
		stepVector = speed * direction.normalized;

	}

	void FixedUpdate () {
		rigidBody.velocity = stepVector;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.name);
	}
}
