using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyNew : MonoBehaviour {

	private const int 	
	IDLEPRE = 0,
	IDLE = 1, //avant que l'enigme soit activée
	ANIMINTRO = 2, //l'anim de jonction, le joueur place l'artefact
	BLOQUER = 3,  //bloquage temporaire, le joueur doit résoudre l'énigme
	RESOLUTION = 4, //l'énigme est résolue, l'anim montre le joueur reprendre l'artefact
	IDLEFIN = 5; // l'enigme est terminer et on ne sait plus y acceder.

	public int 
	state,
	RollState;

	GameObject 
		Artefact,
	ArtefactOnPrey,
	Player,
	CameraPrey,
	AutelPreyPre,
	AutelPrey,
	AutelAnimFin,
	CanvasPrey1Place,
	CanvasPrey2Blocked,
	town2blue;

	public GameObject[] Roll;

	bool
	playerIsHere,
	waitBeforeAction,
	GetInGetOut,
	iAmOn,
	ActivateEnigma,
	CheckHalfSec,
	Enigme2End;

	Animator PlotsEnigme2,
	EndEnigme2;

	GameManager GM;
	DeathSystem DS;
	public EnigmeManager EM;

	// Use this for initialization
	void Start () {
		
		Player = GameObject.Find ("Player");
		CameraPrey = GameObject.Find ("CameraEnigmePrey");
		CameraPrey.SetActive (false);

		town2blue = GameObject.Find ("Town2blue");

		AutelPreyPre = GameObject.Find ("Autel Artefact Prey Pre");
		AutelPrey = GameObject.Find ("Autel Artefact Prey");
		AutelAnimFin = GameObject.Find ("Autel Artefact Prey fin Anim");

		CanvasPrey1Place = GameObject.Find ("CanvasPreyPlace");
		CanvasPrey2Blocked = GameObject.Find ("CanvasPreyBlocked");

		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		DS = GameObject.Find ("ScriptManager").GetComponent<DeathSystem> ();

		Roll = GameObject.FindGameObjectsWithTag ("RollPrey");
		ArtefactOnPrey = GameObject.Find ("artefactPrey");
		ArtefactOnPrey.SetActive (false);

		PlotsEnigme2 = GameObject.Find ("123Animator").GetComponent<Animator> ();
		EndEnigme2 = GameObject.Find ("AnimationPorteEndEnigme2").GetComponent<Animator> ();
		StartCoroutine ("waitForAnimIntro");

		EM.enabled = false;

		CanvasPrey1Place.GetComponent<Canvas> ().enabled = false;
		CanvasPrey2Blocked.GetComponent<Canvas> ().enabled = false;

		state = IDLEPRE;
	}

	IEnumerator waitForAnimIntro(){
		yield return new WaitForSeconds (6.0f);
		Artefact = GameObject.Find ("ARtefactOverLayInteraction");

	}

	void FixedUpdate () {
		switch (state) {

		case IDLEPRE:
			ArtefactOnPrey.SetActive (false);

			AutelPreyPre.SetActive (true);
			AutelPrey.SetActive (false);
			AutelAnimFin.SetActive (false);

			if (Input.GetButtonDown ("Submit") && playerIsHere) {
				state = IDLE;
			}
			break;

		case IDLE:

			AutelPreyPre.SetActive (false);
			AutelPrey.SetActive (true);

			CanvasPrey1Place.GetComponent<Canvas> ().enabled = true;

			if (Input.GetButtonDown ("E") && playerIsHere) {
				state = ANIMINTRO;
			}

			break;

		case ANIMINTRO:
			Artefact.SetActive (false);
			ArtefactOnPrey.SetActive (true);
			ActivateEnigma = true;
			PlotsEnigme2.SetBool ("activateEnigma", ActivateEnigma);
			EM.enabled = true;
			DS.preyMort = true;
			CanvasPrey1Place.GetComponent<Canvas> ().enabled = false;
			CanvasPrey2Blocked.GetComponent<Canvas> ().enabled = true;
			state = BLOQUER;
			break;

		case BLOQUER:
			if (!CheckHalfSec) {
				if (EM.number [0] == 3 && EM.number [1] == 3 && EM.number [2] == 3 && EM.number [3] == 3) {
					StartCoroutine ("End");
				}
				StartCoroutine ("HalfCheck");
			}
			break;

		case RESOLUTION:

			GameObject.Find ("Player").transform.position = GameObject.Find ("RespawnEnigmePrey").transform.position;
			CanvasPrey2Blocked.GetComponent<Canvas> ().enabled = false;
			Enigme2End = true;
			EndEnigme2.SetBool ("endEnigme2", Enigme2End);
			Artefact.SetActive (true);
			ArtefactOnPrey.SetActive (false);
			ActivateEnigma = false;
			PlotsEnigme2.SetBool ("activateEnigma", ActivateEnigma);
			StartCoroutine ("FinEnigme2");
			DS.preyMort = false;
			GM.DesactiverActionDisponibleLacherCube ();
			GM.DesactiverAnimSpeed ();
			AutelPrey.SetActive (false);
			AutelAnimFin.SetActive (true);

			GameObject.Find ("AnimationAutelFinPrey").GetComponent<Animator> ().SetBool ("goFinTotem", Enigme2End);

			break;

		case IDLEFIN:
			this.gameObject.GetComponent<EnigmeManager> ().enabled = false;
			this.gameObject.GetComponent<PreyNew> ().enabled = false;
			break;

		default:
			break;
		}
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

	IEnumerator waitAction(){
		yield return new WaitForSeconds (0.5f);
		waitBeforeAction = false;
	}

	IEnumerator WaitHalfSecBeforeAction(){
		yield return new WaitForSeconds (0.5f);
		GetInGetOut = false;
	}

	IEnumerator HalfCheck(){
		yield return new WaitForSeconds (0.5f);
		CheckHalfSec = false;
	}

	IEnumerator FinEnigme2(){
		yield return new WaitForSeconds (0.1f);
		Enigme2End = false;
		yield return new WaitForSeconds (4.9f);
		GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ().sanity = 1.0f;

		town2blue.GetComponent<goingUpDown> ().enabled = false;
		town2blue.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", 0.0f);
		state = IDLEFIN;
	}

	IEnumerator End () {
		yield return new WaitForSeconds (2.0f);
		state = RESOLUTION;
	}
}
