using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeIsHereSmall : MonoBehaviour {

	ZoneGestion ZG;



	// Use this for initialization
	void Start () {
		
		ZG = GameObject.Find ("ScriptManager").GetComponent<ZoneGestion> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay (Collider coll) {
		if (coll.tag == "Cube") {
//				ZG.cubeIsHereSmall = true;
		}
	}
}
