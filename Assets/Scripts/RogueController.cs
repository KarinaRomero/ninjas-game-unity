using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueController : MonoBehaviour {

	PlayerContoller playerController;

	// Use this for initialization
	void Start () {
		playerController = GameObject.Find("Rogue_03").GetComponent<PlayerContoller>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log (other.gameObject.name);
		Debug.Log (playerController.gameObject.name);
		if(other.gameObject.name == "cheast"){
			playerController.SetControllerCheast (other.gameObject.GetComponent<ChestController>());
		}
	} 
}
