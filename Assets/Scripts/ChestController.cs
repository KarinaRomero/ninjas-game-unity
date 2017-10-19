using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {
	
	public int chestLife;
	Animator animator;

	// Use this for initialization
	void Start () {
		chestLife = 2;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsChestAvailable(){
		bool chestAvailable = true;

		chestLife--;
		animator.SetTrigger ("Disapear");

		if(chestLife <= 0 ){
			chestAvailable = false;
		}

		return chestAvailable;
	}

	/*
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Before Collision :D");
		if(other.tag == "rogue"){
			Debug.Log ("Collision :D");
			Destroy(other.gameObject);
		}
	}*/
}
