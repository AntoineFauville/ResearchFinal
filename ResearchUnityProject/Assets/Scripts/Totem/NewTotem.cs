using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTotem : MonoBehaviour {

	private const int 	IDLE = 0, //avant que le totem soit activé
						ANIMINTRO = 1, //l'anim de jonction, le joueur place l'artefact
						BLOQUER = 2,  //bloquage temporaire, le joueur doit résoudre l'énigme
						RESOLUTION = 3, //l'énigme est résolue, l'anim montre le joueur reprendre l'artefact
						IDLEFIN = 4; // le totem est terminer et on ne sait plus y acceder.

	public int state;

	bool 	
	GetInGetOut, 
	playerIsHere,
	iAmOn,
	totemBool,
	state1,
	state2,
	state3,
	canIUseItDown,
	canIUseItMid,
	canIUseItUp,
	returnAxisBool,
	totemBoolgoAnimtot;

	Animator anim,animCamTotem;

	GameObject 	
	Artefact,
	Player,
	//CameraTotem,
	CameraMap;

	public GameObject 
	OutlineDown,
	OutlineMid,
	OutlineTop,
	MidPart,DownPart,
	TopPartScript,MidPartScript,DownPartScript;

	public RotationEnigmeLazer RotationDown;
	public RotationEnigmeLazer RotationMid;
	public AnimTopPartNotMoving RotationUp;


	// Use this for initialization
	void Start () {
		state = IDLE;
		anim = GameObject.Find ("referenceCubeAnim").GetComponent<Animator>();
		animCamTotem = GameObject.Find ("AnimatorCameraTotem").GetComponent<Animator>();
		StartCoroutine ("waitForAnimIntro");

		Player = GameObject.Find ("Player");
		CameraMap = GameObject.Find ("CameraMap");
		//CameraTotem = GameObject.Find ("CameraEnigmeTotem");

		// rotation gestion totem

		state1 = false;
		state2 = false;
		state3 = false;
		OutlineDown.SetActive(false);
		OutlineMid.SetActive (false);
		OutlineTop.SetActive (false);

	}

	IEnumerator waitForAnimIntro(){
		yield return new WaitForSeconds (6.0f);
		Artefact = GameObject.Find ("ARtefactOverLayInteraction");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (state) {

		case IDLE:

			if (Input.GetButtonDown ("Submit") && playerIsHere) {
				state = ANIMINTRO;
			}

			break;

		case ANIMINTRO:

			totemBool = true;
			anim.SetBool ("GoAnim", totemBool);
			Artefact.SetActive (false);
			state = BLOQUER;
			break;

		case BLOQUER:

			if (Input.GetButtonDown ("Submit") && playerIsHere && !GetInGetOut) {
				if (!iAmOn) {
					Player.SetActive (false);
					totemBoolgoAnimtot = true;
					animCamTotem.SetBool ("goAnimtot",totemBoolgoAnimtot);
					iAmOn = true;
					GetInGetOut = true;
					state1 = true;
					CameraMap.SetActive (false);
					StartCoroutine ("WaitHalfSecBeforeAction");
				} else {
					StartCoroutine ("waitforcamtocomeback");
					totemBoolgoAnimtot = false;
					animCamTotem.SetBool ("goAnimtot",totemBoolgoAnimtot);
					iAmOn = false;
					GetInGetOut = true;
					CameraMap.SetActive (true);

					state1 = false;
					state2 = false;
					state3 = false;

					OutlineDown.SetActive (false);
					OutlineMid.SetActive (false);
					OutlineTop.SetActive (false);

					canIUseItDown = false;
					canIUseItMid = false;
					canIUseItUp = false;

					StartCoroutine ("WaitHalfSecBeforeAction");
				}
			}
			//rotation gestion of the totem
			RotationDown.canIUseIt = canIUseItDown; 
			RotationMid.canIUseIt = canIUseItMid;
			RotationUp.canIUseIt = canIUseItUp;

			if (state1) {
				canIUseItDown = true;
				canIUseItMid = false;
				canIUseItUp = false;

				OutlineDown.SetActive (true);
				OutlineMid.SetActive (false);
				OutlineTop.SetActive (false);
			} else if (state2) {
				canIUseItDown = false;
				canIUseItMid = true;
				canIUseItUp = false;

				OutlineDown.SetActive (false);
				OutlineMid.SetActive (true);
				OutlineTop.SetActive (false);
			} else if (state3) {
				canIUseItDown = false;
				canIUseItMid = false;
				canIUseItUp = true;

				OutlineDown.SetActive (false);
				OutlineMid.SetActive (false);
				OutlineTop.SetActive (true);
			}

			if (state1 && Input.GetAxis ("Vertical") >= 0.4f && !returnAxisBool) {
				state1 = false;
				state2 = true;
				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			} else if (state2 && Input.GetAxis ("Vertical") >= 0.4f && !returnAxisBool) {
				state2 = false;
				state3 = true;
				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}
			if (state3 && Input.GetAxis ("Vertical") <= -0.4f && !returnAxisBool) {
				state3 = false;
				state2 = true;
				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			} else if (state2 && Input.GetAxis ("Vertical") <= -0.4f && !returnAxisBool) {
				state2 = false;
				state1 = true;
				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}

			Quaternion currentRotationPart2 = (MidPart.transform.rotation);
			Quaternion currentRotationPart3 = (DownPart.transform.rotation);

			float rot2 = Mathf.Abs (currentRotationPart2.y);
			float rot3 = Mathf.Abs (currentRotationPart3.y);
			bool gotThisOnce = false;


			if(rot2 == 1.0f && rot3 == 1.0f  && !gotThisOnce){
				
				StartCoroutine ("waitforcamtocomeback");
				totemBoolgoAnimtot = false;
				animCamTotem.SetBool ("goAnimtot",totemBoolgoAnimtot);
				iAmOn = false;
				GetInGetOut = true;
				CameraMap.SetActive (true);

				TopPartScript.GetComponent<AnimTopPartNotMoving> ().enabled = false;
				MidPartScript.GetComponent<RotationEnigmeLazer> ().enabled = false;
				DownPartScript.GetComponent<RotationEnigmeLazer> ().enabled = false;

				state1 = false;
				state2 = false;
				state3 = false;

				OutlineDown.SetActive (false);
				OutlineMid.SetActive (false);
				OutlineTop.SetActive (false);

				canIUseItDown = false;
				canIUseItMid = false;
				canIUseItUp = false;

				print ("EnigmaTotemDone");
				state = RESOLUTION;

				gotThisOnce = true;
				//	}
			}

			break;

		case RESOLUTION:

			state1 = false;
			state2 = false;
			state3 = false;

			OutlineDown.SetActive (false);
			OutlineMid.SetActive (false);
			OutlineTop.SetActive (false);

			canIUseItDown = false;
			canIUseItMid = false;
			canIUseItUp = false;

			totemBool = false;
			anim.SetBool ("GoAnim", totemBool);
			Artefact.SetActive (true);
			state = IDLEFIN;

			break;

		case IDLEFIN:
			break;

		default:
			break;
		}

		//gestion rotation 




	}

	void OnTriggerEnter (Collider coll){
		if (coll.tag == "Player") {
			playerIsHere = true;
		}
	}
	void OnTriggerExit (Collider coll){
		if (coll.tag == "Player") {
			playerIsHere = false;
		}
	}

	IEnumerator WaitHalfSecBeforeAction(){
		yield return new WaitForSeconds (0.5f);
		GetInGetOut = false;
	}

	IEnumerator returnAxis(){
		yield return new WaitForSeconds (0.5f);
		returnAxisBool = false;
	}

	IEnumerator waitforcamtocomeback  () {
		yield return new WaitForSeconds (1.45f);
		Player.SetActive (true);
	}

}
