using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyNew : MonoBehaviour {

	private const int 	IDLE = 0, //avant que l'enigme soit activée
	ANIMINTRO = 1, //l'anim de jonction, le joueur place l'artefact
	BLOQUER = 2,  //bloquage temporaire, le joueur doit résoudre l'énigme
	RESOLUTION = 3, //l'énigme est résolue, l'anim montre le joueur reprendre l'artefact
	IDLEFIN = 4; // l'enigme est terminer et on ne sait plus y acceder.

	public int state,RollState;

	GameObject 
		Artefact,
	ArtefactOnPrey,
	Player,
	CameraPrey;

	public GameObject[] Roll;

	bool
	playerIsHere,
	waitBeforeAction,
	GetInGetOut,
	iAmOn;

	GameManager GM;
	DeathSystem DS;

	// Use this for initialization
	void Start () {
		state = IDLE;
		Player = GameObject.Find ("Player");
		CameraPrey = GameObject.Find ("CameraEnigmePrey");
		CameraPrey.SetActive (false);
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		DS = GameObject.Find ("Player").GetComponent<DeathSystem> ();
		//Roll = GameObject.FindGameObjectsWithTag ("RollPrey");
		ArtefactOnPrey = GameObject.Find ("artefactPrey");
		ArtefactOnPrey.SetActive (false);
		StartCoroutine ("waitForAnimIntro");
	}

	IEnumerator waitForAnimIntro(){
		yield return new WaitForSeconds (6.0f);
		Artefact = GameObject.Find ("ARtefactOverLayInteraction");

	}

	void FixedUpdate () {
		switch (state) {

		case IDLE:
			ArtefactOnPrey.SetActive (false);
			if (Input.GetButtonDown ("Submit") && playerIsHere) {
				state = ANIMINTRO;
			}
			break;

		case ANIMINTRO:
			Artefact.SetActive (false);
			ArtefactOnPrey.SetActive (true);
			state = BLOQUER;
			break;

		case BLOQUER:

			// activer désactiver chaque pilier a raison de 4
			/*if (Input.GetButtonDown ("Submit") && playerIsHere && !GetInGetOut) {
				if (!iAmOn) {
					
					Player.SetActive (false);
					CameraPrey.SetActive (true);

					iAmOn = true;
					GetInGetOut = true;
					StartCoroutine ("WaitHalfSecBeforeAction");
				} else {
					
					Player.SetActive (true);
					CameraPrey.SetActive (false);

					iAmOn = false;
					GetInGetOut = true;
					StartCoroutine ("WaitHalfSecBeforeAction");
				}
			}

			//Tableau d'éléments Rouleau de prière
			// monter descendre chaqu'un des piliers a raison de 3 positions pos1 : Y=3 pos2 : Y=2 pos3 = Y=1
			//lorsque je fais horizontal => change d'élément de mon tableau
			//lorsque je fais vertical => modifie la position de mon élément de tableau
			//je fais check pour tout les i de mon tableau si ils ont une position particuliere si oui => win
			// lorsque les 4 sont allignés au centre Y1 + Y2 + Y3 + Y4 = 2 => Résolution

			// 1 passer de l'un a l'autre
			if (Input.GetAxis ("Horizontal") > 0.2f && !waitBeforeAction) {

				RollState += 1;

				waitBeforeAction = true;
				StartCoroutine ("waitAction");
			}

			if (Input.GetAxis ("Horizontal") < -0.2f && !waitBeforeAction) {

				RollState -= 1;

				waitBeforeAction = true;
				StartCoroutine ("waitAction");
			}

			if (RollState < 0) {
				RollState = Roll.Length-1;
			}

			if (RollState > Roll.Length-1) {
				RollState = 0;
			}





			for (int i = 0; i < Roll.Length; i++) {
				if (i != RollState) {
					Roll [i].transform.GetChild (i).gameObject.SetActive (false);
				}

				if (Input.GetButtonDown ("Vertical") && !waitBeforeAction) {



					waitBeforeAction = true;
					StartCoroutine ("waitAction");
				}
			}
*/

			break;

		case RESOLUTION:



			break;

		case IDLEFIN:
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
}
