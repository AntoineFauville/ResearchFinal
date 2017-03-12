using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDoor : MonoBehaviour {

	public float animationTime = 12.0f;

	public bool isPlayerHere,
			PlayOnce;

	GameObject Player,
				CameraTriggerShow;

	Animator animShowDoor;

	// Use this for initialization
	void Start () {
		CameraTriggerShow = GameObject.FindGameObjectWithTag ("cameraTriggerShow");
		Player = GameObject.Find ("Player");
		animShowDoor = GameObject.Find ("AnimationReferenceTriggerShowDoor").GetComponent<Animator> ();
	}

	void Update(){
		animShowDoor.SetBool ("ShowDoorAnim",isPlayerHere);
		if (isPlayerHere && !PlayOnce) {
			StartCoroutine ("AnimationShowDoor");
		}
	}

	void OnTriggerStay (Collider coll) {
		if (coll.tag == "Player") {
			isPlayerHere = true;
		}
	}

	IEnumerator AnimationShowDoor () {

		Player.SetActive (false);
		PlayOnce = true;

		yield return new WaitForSeconds (animationTime);
		CameraTriggerShow.SetActive (false);
		Player.SetActive (true);


	}
}
