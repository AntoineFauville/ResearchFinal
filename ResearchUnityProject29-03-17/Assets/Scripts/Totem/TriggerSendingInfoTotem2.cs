using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSendingInfoTotem2: MonoBehaviour {

	bool PlayerIsHere;

	bool didWeAllreadyCheckThis;

	public bool GoodToGoTotem02;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerIsHere && !didWeAllreadyCheckThis){
			didWeAllreadyCheckThis = true;
			GoodToGoTotem02 = true;
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			PlayerIsHere = true;
		}	
	}

	void OnTriggerExit (Collider coll) {
		if (coll.tag == "Player") {
			PlayerIsHere = false;
		}	
	}
}
