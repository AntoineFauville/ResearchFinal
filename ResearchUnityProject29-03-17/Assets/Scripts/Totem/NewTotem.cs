using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Rendering;

public class NewTotem : MonoBehaviour {

	private const int 	
		IDLEBEFORE = 0, //idle d'avant qu'on ne voit le totem 	press space
		IDLE = 1, //avant que le totem soit activé 			press E
		ANIMINTRO = 2, //l'anim de jonction, le joueur place l'artefact
		BLOQUER = 3,  //bloquage temporaire, le joueur doit résoudre l'énigme
		RESOLUTION = 4, //l'énigme est résolue, l'anim montre le joueur reprendre l'artefact
		IDLEFIN = 5; // le totem est terminer et on ne sait plus y acceder.

	public int state,
	totemRotationPart;

	bool 	
	GetInGetOut, 
	playerIsHere,
	iAmOn,
	totemBool,
	returnAxisBool,
	totemBoolgoAnimtot,
	goOnce,
	cesameOuvreToi,
	Left,
	Right,
	gotThisOnce,
	gotAlsoThisOnce,
	AppearAutel;

	public bool totemScript;

	Animator 
	anim,
	animCamTotem,
	DoorAnimator,
	AnimatorFinTotem;

	public GameObject[] PartieDeTotem;
	GameObject[] QuadResol;

	GameObject 	
	Artefact,
	Player,
	ArtefactTotem,
	forResolution1,
	forResolution2,
	cameraAnimTotemFin,
	MidPart,
	DownPart,
	MainCamera,
	MainCameraUI,
	CameraMap,
	AutelPre,
	AutelTotem;

	float 
	amount = 1.0f;

	GameManager GM;
	DeathSystem DS;
	SanityGestion SG;

	// Use this for initialization
	void Start () {
		state = IDLEBEFORE;

		MainCamera = GameObject.Find ("Main Camera Main");
		MainCameraUI = GameObject.Find ("Main Camera Main UI");

		AutelPre = GameObject.Find ("Autel Artefact Pre totem");
		AutelTotem = GameObject.Find ("Autel Artefact totem");

		cameraAnimTotemFin = GameObject.FindGameObjectWithTag ("cameraFinTotem");
		cameraAnimTotemFin.GetComponent<Camera>().enabled = false;

		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		DS = GameObject.Find ("ScriptManager").GetComponent<DeathSystem> ();
		SG = GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ();

		ArtefactTotem = GameObject.Find ("ActualCubeTotem");

		//animation d'entrée de placement du cube

		anim = GameObject.Find ("referenceCubeAnim").GetComponent<Animator>();

		//rotation du totem

		MidPart = GameObject.Find ("MiddlePartTotem");
		DownPart = GameObject.Find ("DownPartTotem");
		PartieDeTotem = GameObject.FindGameObjectsWithTag ("TotemRotation");

		//animation de camera du totem entrée sortie appuyer sur espace

		animCamTotem = GameObject.Find ("AnimatorCameraTotem").GetComponent<Animator>();

		//animation de fin

		DoorAnimator = GameObject.Find ("Animation door").GetComponent<Animator>();
		AnimatorFinTotem = GameObject.Find ("AnimatorTotemFin").GetComponent<Animator>();

		// indice

		forResolution1 = GameObject.Find ("ForResolution01");
		forResolution1.SetActive (false);
		forResolution2 = GameObject.Find ("ForResolution02");
		forResolution2.SetActive (false);

		//player

		Player = GameObject.Find ("Player");

		AutelPre.SetActive (false);
		AutelTotem.SetActive (false);

		//CameraTotem = GameObject.Find ("CameraEnigmeTotem");

		// rotation gestion totem

		/*state1 = false;
		state2 = false;
		state3 = false;*/

		//outline

		for (int i = 0; i < PartieDeTotem.Length; i++) {
				PartieDeTotem [i].gameObject.transform.GetChild (0).gameObject.SetActive (false);
		}

		StartCoroutine ("waitForAnimIntro");

	}

	IEnumerator waitForAnimIntro(){
		yield return new WaitForSeconds (0.5f);
		GameObject.Find ("Town1").GetComponent<AppearVillage> ().enabled = false;
		yield return new WaitForSeconds (5.5f);
		Artefact = GameObject.Find ("ARtefactOverLayInteraction");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (state) {

		case IDLEBEFORE:
			ArtefactTotem.SetActive (false);

			if (playerIsHere && !gotAlsoThisOnce) {
				gotAlsoThisOnce = true;
				AppearAutel = true;
			}

			if (AppearAutel) {
				StartCoroutine ("Appear");
				AutelPre.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);
				amount -= 0.01f * Time.deltaTime * 30;
			}


			if (Input.GetButtonDown ("Submit") && playerIsHere) {
				state = IDLE;
			}

			break;

		case IDLE:

			AutelPre.SetActive (false);
			AutelTotem.SetActive (true);

			if (Input.GetButtonDown ("E") && playerIsHere) {
				GameObject.Find ("Town1").GetComponent<AppearVillage> ().enabled = true;
				state = ANIMINTRO;
			}
			break;

		case ANIMINTRO:

			totemBool = true;
			anim.SetBool ("GoAnim", totemBool);

			Artefact.SetActive (false);
			ArtefactTotem.SetActive (true);

			DS.EnigmeActiveeMortSystemOn = true;

			forResolution1.SetActive (true);
			forResolution2.SetActive (true);

			state = BLOQUER;

			break;

		case BLOQUER:
			
			//rentrer sortir + animation

			if (Input.GetButtonDown ("E") && playerIsHere && !GetInGetOut) {
				if (!iAmOn) {

					MainCamera.GetComponent<Camera> ().enabled = false;
					MainCameraUI.GetComponent<Camera> ().enabled = false;
					Player.GetComponent<FirstPersonController> ().enabled = false;


					totemBoolgoAnimtot = true;
					animCamTotem.SetBool ("goAnimtot", totemBoolgoAnimtot);
					SG.enabled = false;
					GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = false;
					iAmOn = true;
					GetInGetOut = true;

					StartCoroutine ("WaitHalfSecBeforeAction");

				} else {
					
					StartCoroutine ("waitforcamtocomeback");

					totemBoolgoAnimtot = false;
					animCamTotem.SetBool ("goAnimtot", totemBoolgoAnimtot);

					SG.enabled = true;

					iAmOn = false;
					GetInGetOut = true;

					StartCoroutine ("WaitHalfSecBeforeAction");
				}
			}

			//gestion des rotations

			PartieDeTotem [totemRotationPart].GetComponent<Animator> ().SetBool ("right", Right);
			PartieDeTotem [totemRotationPart].GetComponent<Animator> ().SetBool ("left", Left);

			//monter
			if (iAmOn && (Input.GetAxis ("Vertical") > 0.3f || Input.GetButtonDown ("Up")) && !returnAxisBool) {

				totemRotationPart++;

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}
			//descendre
			if (iAmOn && (Input.GetAxis ("Vertical") < -0.3f || Input.GetButtonDown ("Down")) && !returnAxisBool) {

				totemRotationPart--;

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}
			//gauche
			if (iAmOn && (Input.GetAxis ("Horizontal") < -0.3f || Input.GetButtonDown ("left")) && !returnAxisBool) {

				Left = true;
				StartCoroutine ("leftRightBack");

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}
			//droite
			if (iAmOn && (Input.GetAxis ("Horizontal") > 0.3f || Input.GetButtonDown ("right")) && !returnAxisBool) {

				Right = true;
				StartCoroutine ("leftRightBack");

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}

			if (totemRotationPart < 0) {
				totemRotationPart = PartieDeTotem.Length - 1;
			}

			if (totemRotationPart > PartieDeTotem.Length - 1) {
				totemRotationPart = 0;
			}

			//gestion des overlays

			PartieDeTotem [totemRotationPart].gameObject.transform.GetChild (0).gameObject.SetActive (true);

			for (int i = 0; i < PartieDeTotem.Length; i++) {
				
				if (i != totemRotationPart) {
					PartieDeTotem [i].gameObject.transform.GetChild (0).gameObject.SetActive (false);
				}
			}


			Quaternion currentRotationPart2 = (MidPart.transform.rotation);
			Quaternion currentRotationPart3 = (DownPart.transform.rotation);

			float ymid = MidPart.transform.rotation.eulerAngles.y;
			float ydown = DownPart.transform.rotation.eulerAngles.y;

			//print (ymid);
			//print (ydown);

			float rot2 = Mathf.Abs (currentRotationPart2.y);
			float rot3 = Mathf.Abs (currentRotationPart3.y);

			if (ymid == ydown && ymid > 85 && ymid < 96 && !gotThisOnce) {
				StartCoroutine ("waitforcamtocomeback");
				totemBoolgoAnimtot = false;
				animCamTotem.SetBool ("goAnimtot",totemBoolgoAnimtot);
				iAmOn = false;
				GetInGetOut = true;
				gotThisOnce = true;
				state = RESOLUTION;
			}

			break;

		case RESOLUTION:

			//state1 = false;
			//state2 = false;
			//state3 = false;

			bool doItOnce = false;

			if (!doItOnce) {
				
				totemBool = false;
				totemScript = true;
				anim.SetBool ("GoAnim", totemBool);
				Artefact.SetActive (true);
				ArtefactTotem.SetActive (false);
				forResolution1.SetActive (false);
				forResolution2.SetActive (false);
				DS.EnigmeActiveeMortSystemOn = false;

				doItOnce = true;

				//door

				StartCoroutine ("EndingAnimation");
			}
			state = IDLEFIN;
			break;

		case IDLEFIN:
			bool doItOnceEnd = false;

			if (!doItOnceEnd) {
				ArtefactTotem.SetActive (false);
				doItOnceEnd = true;
			}

			if (!goOnce) {
				GM.DesactiverActionDisponibleLacherCube ();
				goOnce = true;
			}
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
		MainCamera.GetComponent<Camera> ().enabled = true;
		MainCameraUI.GetComponent<Camera> ().enabled = true;
		GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = true;
		Player.GetComponent<FirstPersonController> ().enabled = true;
	}

	IEnumerator leftRightBack () {
		yield return new WaitForSeconds (0.5f);
		Left = false;
		Right = false;
	}

	IEnumerator EndingAnimation(){
		cameraAnimTotemFin.GetComponent<Camera>().enabled = true;
		MainCamera.GetComponent<Camera> ().enabled = false;
		MainCameraUI.GetComponent<Camera> ().enabled = false;
		GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = false;
		Player.GetComponent<FirstPersonController> ().enabled = false;
		cesameOuvreToi = true;
		DoorAnimator.SetBool ("CesameOuvreToi",cesameOuvreToi);
		AnimatorFinTotem.SetBool ("GoToCesame", cesameOuvreToi);
		yield return new WaitForSeconds (6.3f);
		cameraAnimTotemFin.GetComponent<Camera>().enabled = false;
		GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ().sanity = 1.0f;

		MainCamera.GetComponent<Camera> ().enabled = true;
		MainCameraUI.GetComponent<Camera> ().enabled = true;
		Player.GetComponent<FirstPersonController> ().enabled = true;

		GameObject.Find ("TopPartTotem").GetComponent<Animator> ().enabled = false;
		GameObject.Find ("MiddlePartTotem").GetComponent<Animator> ().enabled = false;
		GameObject.Find ("DownPartTotem").GetComponent<Animator> ().enabled = false;
		GameObject.Find ("AnimatorCameraTotem").GetComponent<Animator> ().enabled = false;
		GameObject.Find ("referenceCubeAnim").GetComponent<Animator> ().enabled = false;
		QuadResol = GameObject.FindGameObjectsWithTag ("QuadResolution");

		for (int i = 0; i < QuadResol.Length; i++) {
			QuadResol [i].SetActive (false);
		}



		this.gameObject.GetComponent<NewTotem> ().enabled = false;
	}

	IEnumerator Appear (){

		AutelPre.SetActive (true);
		AutelPre.GetComponent<goingUpDown> ().enabled = false;
		AutelPre.GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
		AutelPre.GetComponent<MeshRenderer> ().receiveShadows = false;

		yield return new WaitForSeconds (4.0f);

		AppearAutel = false;

		AutelPre.GetComponent<goingUpDown> ().enabled = true;
	}
}