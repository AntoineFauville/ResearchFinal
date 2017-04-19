using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : MonoBehaviour {

	bool run;

	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Animator> ().SetBool ("runningOn",run);
		if (Input.GetButton ("leftMaj")) {
			run = true;
		} else {
			run = false;
		}
	}
}
