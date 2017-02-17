using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjectives : MonoBehaviour {

	bool firstTimeEnter = false;

	public int triggerID; 

	public ObjectiveStates OS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player" && !firstTimeEnter) {
			firstTimeEnter = true;

			//envoi message
			OS.GoNextPoint(triggerID);

		}
	}
}
