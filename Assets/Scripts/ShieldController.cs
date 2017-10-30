using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

	public float lifeTime;
	// Use this for initialization
	void Start () {
		lifeTime = 2;
		Destroy (gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
