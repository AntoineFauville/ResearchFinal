using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterestPointArea : MonoBehaviour {

	public GameObject image;

	// Use this for initialization
	void Start () {
		image.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			image.SetActive (true);
		}
	}

	void OnTriggerExit (Collider coll) {
		if (coll.tag == "Player") {
			image.SetActive (false);
		}
	}
}
