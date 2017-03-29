using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPersonCamera;

public class hardFocusForSec : MonoBehaviour {

	LockOnTarget LockTargetScript;
	public float secondOfHardFocus = 1.0f;

	// Use this for initialization
	void Start () {
		LockTargetScript = GameObject.Find ("Main Camera Main1").GetComponent<LockOnTarget> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter () {
		LockTargetScript.hardFocus = true;
		StartCoroutine ("returnHardFocus");
	}


	IEnumerator returnHardFocus (){
		yield return new WaitForSeconds (secondOfHardFocus);
		LockTargetScript.hardFocus = false;
		this.gameObject.SetActive (false);
	}
}
