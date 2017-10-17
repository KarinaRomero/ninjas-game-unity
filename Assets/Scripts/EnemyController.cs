using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour {

	public float speed;
	private Rigidbody2D rgb2d;
	private Animator animator;

	public Slider slider;
	public Text energyText;

	public float energy;

	// Use this for initialization
	void Start () {
		speed = -1f;
		energy = 100;
		rgb2d = GetComponent <Rigidbody2D>();
		animator = GetComponent <Animator> ();
	}

	void Update(){
		slider.value = energy;
		energyText.text = energy.ToString ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		Vector2 vector = new Vector2 (speed,0);
		rgb2d.velocity = vector;

		if(animator.GetCurrentAnimatorStateInfo(0).IsName("walk") && Random.value < 1f/(60f*3f)) {
			animator.SetTrigger ("jump");
		}
	}

	void OnTriggerEnter2D (Collider2D other){
		Flip ();
	}

	void Flip(){
		speed *= -1;

		var s = transform.localScale;
		s.x *= -1;

		transform.localScale = s;
	}
}

