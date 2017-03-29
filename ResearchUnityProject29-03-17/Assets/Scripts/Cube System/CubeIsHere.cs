using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeIsHere : MonoBehaviour {
	/*
	ZoneGestion ZG;
	GameObject Artefact;
	GameObject Player;
	DropCube DC;

	// Use this for initialization
	void Start () {
		ZG = GameObject.Find ("ScriptManager").GetComponent<ZoneGestion> ();
		DC = GameObject.Find ("Player").GetComponent<DropCube> ();
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (Player.transform.position, transform.position);
		if(distance < 2 && DC.isCubeOnGround){
			//Artefact = GameObject.Find ("ArtefactArcheo(Clone)");
//			ZG.cubeIsHereInTown = true;
			/*float distanceARte = Vector3.Distance (Artefact.transform.position, transform.position);

			if (distanceARte < 30) {
				ZG.cubeIsHereInTown = true;
			}
		}
		
	}

	/*void OnTriggerStay (Collider coll) {
		if (coll.tag == "Cube") {
			ZG.cubeIsHereInTown = true;
		}
	}*/
}
