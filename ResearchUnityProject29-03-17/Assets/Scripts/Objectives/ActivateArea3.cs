using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateArea3 : MonoBehaviour {

	public GameObject area3,
	everythinginvisibleArea2;

	void Start(){
		area3.SetActive (false);
		everythinginvisibleArea2.SetActive (false);
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player") {
			area3.SetActive (true);
			everythinginvisibleArea2.SetActive (true);
		}
	}
}
