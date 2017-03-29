using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Event1 : MonoBehaviour {
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
	artefactSurUI;


	DeathSystem DS;

	// Use this for initialization
	void Start () {

		DS = GameObject.Find ("ScriptManager").GetComponent<DeathSystem> ();

		MainCamera = GameObject.Find ("Main Camera Main");
		Player = GameObject.Find ("Player");
		artefactTuto = GameObject.Find ("ArtefactTuto");
		artefactTuto.SetActive (false);
		//artefactSurFesses = GameObject.Find ("ArtefactOnAss");

		DLM = GameObject.Find ("SmallItem1").GetComponent<DetectableLocalManager> ();

		StartCoroutine ("waitforIntro");
	}
	

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
		StartCoroutine ("NewUpdate");
	}

	IEnumerator NewUpdate(){
		yield return new WaitForSeconds (0.005f);
		bool finishedAndPlayerNear = false;
		//demander au joueur d'appuyer sur submit (espace ou entrée)

		if (DLM.isPlayerHere && !tutorialFinished && Input.GetButtonDown ("Submit") && !pressed) {
			pressed = true;
			//launch tutorial
			StartCoroutine("animationQuiBloqueAMoitieLeCube");


			// pour récuperer le cube le joueur doit rappuyer sur submit (espace ou entrée)

			// pour récuperer le cube le joueur doit rappuyer sur submit (espace ou entrée)

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
	}
}
