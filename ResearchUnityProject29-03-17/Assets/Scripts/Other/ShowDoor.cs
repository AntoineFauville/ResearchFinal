using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowDoor : MonoBehaviour {

	public float animationTime = 12.0f;

	public bool isPlayerHere,
			PlayOnce;

	GameObject Player,
	CameraTriggerShow,
	MainCamera,
	MainCameraUI;

	Animator animShowDoor;

	// Use this for initialization
	void Start () {
		MainCamera = GameObject.Find ("Main Camera Main");
		MainCameraUI = GameObject.Find ("Main Camera Main UI");
		CameraTriggerShow = GameObject.FindGameObjectWithTag ("cameraTriggerShow");
		CameraTriggerShow.SetActive (false);
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
		CameraTriggerShow.SetActive (true);
		MainCamera.GetComponent<Camera> ().enabled = false;
		MainCameraUI.GetComponent<Camera> ().enabled = false;
		Player.GetComponent<FirstPersonController> ().enabled = false;
		GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = false;
		PlayOnce = true;

		yield return new WaitForSeconds (animationTime);
		CameraTriggerShow.SetActive (false);
		MainCamera.GetComponent<Camera> ().enabled = true;
		MainCameraUI.GetComponent<Camera> ().enabled = true;
		Player.GetComponent<FirstPersonController> ().enabled = true;
		GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = true;

		GameObject.Find ("TriggerShowDoor").gameObject.SetActive (false);

	}
}
