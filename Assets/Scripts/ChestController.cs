using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour {
	
	public int chestLife;
	Animator animator;

	// Use this for initialization
	void Start () {
		chestLife = 1;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsChestAvailable(){
		bool chestAvailable = true;

		chestLife--;
		//

		if(chestLife <= 0 ){
			animator.SetTrigger ("Disappear");
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
