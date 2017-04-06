using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event1 : MonoBehaviour {

	private const int 
			AVANT = 0,   //moment ou l'objet est en train de glitcher
			PRETUTO = 1,	//moment ou l'on pose l'artefact et ou le pressE est activer
			TUTO = 2,	//moment ou l'on doit ramasser l'artefact après l'avoir poser
			TOIDLEFIN = 3,
			FINIDLE = 4;

	public int state;

	public Animator image;

	DetectableLocalManager DLM;

	public bool tutorialFinished = false;
	bool pressed = false;
	bool pressed2 = false;
	bool artefactBloquer = false;

	public float secondstoWait;

	//parametre d'animation
	public Animator anim;
	bool animation;

	GameObject Player, 
	MainCamera,
	artefactSurFesses,
	artefactTuto,
	artefactSurUI,

	AutelBeforeTuto,
	AutelAnimationTuto;

	DeathSystem DS;

	// Use this for initialization
	void Start () {

		DS = GameObject.Find ("ScriptManager").GetComponent<DeathSystem> ();

		GameObject.Find ("CanvasTuto").GetComponent<Canvas>().enabled = false;


		MainCamera = GameObject.Find ("Main Camera Main");
		Player = GameObject.Find ("Player");
		artefactTuto = GameObject.Find ("ArtefactTuto");
		artefactTuto.SetActive (false);
		//artefactSurFesses = GameObject.Find ("ArtefactOnAss");

		DLM = GameObject.Find ("SmallItem1").GetComponent<DetectableLocalManager> ();

		AutelBeforeTuto = GameObject.Find ("Autel Artefact tuto pre");
		AutelAnimationTuto = GameObject.Find ("AnimationTuto");

		StartCoroutine ("waitforIntro");

		state = AVANT;
	}
	

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}


	void FixedUpdate () {
		switch (state) {

		case AVANT:

			//l'objet glitch
			AutelBeforeTuto.SetActive (true);
			AutelAnimationTuto.SetActive (false);
			GameObject.Find ("SmallItem1").GetComponent<AppearDistanceTuto> ().enabled = false;


			if (Input.GetButtonDown ("Submit") && DLM.isPlayerHere) {
				GameObject.Find ("CanvasTuto").GetComponent<Canvas>().enabled = true;

				state = PRETUTO;
			}

			break;

		case PRETUTO:

			//
			AutelBeforeTuto.SetActive (false);
			AutelAnimationTuto.SetActive (true);
			GameObject.Find ("SmallItem1").GetComponent<AppearDistanceTuto>().enabled = true;


			if (Input.GetButtonDown ("E") && DLM.isPlayerHere) {

				artefactTuto.SetActive (true);
				artefactSurUI.SetActive (false);

				GameObject.Find ("CanvasTuto").GetComponent<Canvas>().enabled = false;

				animation = true;
				anim.SetBool("AnimActiv",animation);

				state = TUTO;
			}

			break;

		case TUTO:

			if (Input.GetButtonDown ("Submit")) {
				image.SetBool ("Ping", animation);
			}

			if (Input.GetButtonDown ("E") && DLM.isPlayerHere) {
				state = TOIDLEFIN;
			}

			break;

		case TOIDLEFIN:

			artefactTuto.SetActive (false);
			artefactSurUI.SetActive (true);
			DS.tutoMort = false;
			GameObject.Find ("ScriptManager").GetComponent<GameManager> ().DesactiverActionDisponibleLacherCube ();
			GameObject.Find ("ScriptManager").GetComponent<GameManager> ().DesactiverAnimSpeed ();
			GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ().sanity = 1.0f;

			GameObject.Find ("Autel Artefact tuto").GetComponent<GlowObject> ().enabled = false;

			animation = false;
			image.SetBool ("Ping", animation);

			state = FINIDLE;

			break;

		case FINIDLE:

		break;

		}
	}

	/*
	IEnumerator NewUpdate(){
		yield return new WaitForSeconds (0.005f);
		bool finishedAndPlayerNear = false;
		//demander au joueur d'appuyer sur submit (espace ou entrée)

		if (DLM.isPlayerHere && !tutorialFinished && Input.GetButtonDown ("Submit") && !pressed) {
			pressed = true;
			//launch tutorial
			StartCoroutine("animationQuiBloqueAMoitieLeCube");

			//launch anim ou le joueur ramasse le cube
		}

		if (artefactBloquer && Input.GetButtonDown ("Submit") && !pressed2) {
			tutorialFinished = true;

			GameObject.Find ("ScriptManager").GetComponent<GameManager> ().DesactiverActionDisponibleLacherCube ();

			artefactTuto.SetActive (false);
			artefactSurUI.SetActive (true);

			DS.tutoMort = false;
			GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ().sanity = 1.0f;

			pressed2 = true;
		}
		StartCoroutine ("NewUpdate");
	}
	*/
	/*
	IEnumerator animationQuiBloqueAMoitieLeCube () {
		//
		animation = true;
		artefactTuto.SetActive (true);


		anim.SetBool("AnimActiv",animation);
		MainCamera.GetComponent<Camera> ().enabled = false;
		Player.GetComponent<FirstPersonController> ().enabled = false;
		GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = false;


		//fin animation
		yield return new WaitForSeconds (secondstoWait);

		artefactBloquer = true;

		MainCamera.GetComponent<Camera> ().enabled = true;
		Player.GetComponent<FirstPersonController> ().enabled = true;
		GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = true;
		DS.tutoMort = true;

		artefactSurUI.SetActive (false);
	}*/
}
