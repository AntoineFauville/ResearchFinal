using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DetectableLocalManager : MonoBehaviour {

	public bool isPlayerHere;
	bool didIReceive;

	// Use this for initialization
	void Start () {
		StartCoroutine ("everyHalfSec");
	}
	
	// Update is called once per frame
	IEnumerator everyHalfSec () {
		yield return new WaitForSeconds (0.5f);
		if(isPlayerHere){
	//		print ("Hey, You can press E" + gameObject.name);

			//envoi au script local comme quoi le joueur est la et a appuyer sur e
		}
		StartCoroutine ("everyHalfSec");
	}

	public void ImDetectedFar () {
	//	print ("Hey, im detected" + gameObject.name);
	}

	public void YouCanPressE (){
		if (!didIReceive) {
			isPlayerHere = true;
			didIReceive = true;
		}
	}

	public void ICantPressEAnyMore (){
		if (didIReceive) {
			isPlayerHere = false;
			didIReceive = false;
		}
	}

}
