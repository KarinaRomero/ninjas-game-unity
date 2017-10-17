using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

	private Rigidbody2D rgb2d;
	private Animator animator;
	public float speedValue;
	private bool moveRigth;

	public Slider slider;
	public Text energyText;

	public float energy;

	// Use this for initialization
	void Start () {
		moveRigth = true;
		energy = 100;
		rgb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent <Animator> ();
	}

	void Update(){
		slider.value = energy;
		energyText.text = energy.ToString ();
	}
	// Update is called once per frame
	void FixedUpdate () {
		
		float inputValue = Input.GetAxis ("Horizontal");

		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Idle")) {
			animator.SetTrigger ("Walk");
		} else if (animator.GetCurrentAnimatorStateInfo (0).IsName ("Walk")) {
			animator.SetTrigger ("Idle");
		}

		Vector2 speed = new Vector2 (0, rgb2d.velocity.y);

		inputValue *= speedValue;

		speed.x = inputValue;

		rgb2d.velocity = speed;

		animator.SetFloat ("speed", speed.x);

		if (moveRigth && inputValue < 0) {
			moveRigth = false;
			 
			Flip ();
		} else if (!moveRigth && inputValue > 0) {
			moveRigth = true;
			Flip ();
		} 


	}

	void Flip(){
		var s = transform.localScale;
		s.x *= -1;
		transform.localScale = s;


	}
}
