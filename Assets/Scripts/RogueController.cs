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
		//playerController.changeAnimation ();
	}



	void OnTriggerEnter2D(Collider2D other) {
		
			playerController.SetControllerChest (other.gameObject.GetComponent<ChestController>());
	} 
}
