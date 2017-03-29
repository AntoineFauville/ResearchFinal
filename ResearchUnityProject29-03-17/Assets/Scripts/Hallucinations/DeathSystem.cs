using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathSystem : MonoBehaviour {

	GameObject 
	Artefact,
	RespawnEnigme,
	RespawnTuto,
	RespawnEnigmePrey,
	Player;

	public CanvasGroup ImageWhite;
	public float smoothWhiteBeginning = 0.05f;
	public bool amIAtZero = false;
	public bool amIAtMax = false;
	public float secondsBeforeDecreasing = 2.0f;
	private bool goingUp = false;
	private bool goingDown = false;

	//DropCube DC;
	SanityGestion SG;

	public bool EnigmeActiveeMortSystemOn;
	public bool tutoMort;
	public bool preyMort;


	// Use this for initialization
	void Start () {
		//DC = GameObject.Find ("Player").GetComponent<DropCube> ();
		SG = GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ();
		Player = GameObject.Find ("Player");
		RespawnEnigme = GameObject.Find ("RespawnEnigmeTotem");
		RespawnTuto = GameObject.Find ("RespawnTuto");
		RespawnEnigmePrey = GameObject.Find ("RespawnEnigmePrey");
	}
	
	// Update is called once per frame
	void Update () {

		//dans le cas ou je lache par moi meme le cube

	/*	if (DC.isCubeOnGround) {
			Artefact = GameObject.Find ("ArtefactRecherche(Clone)");

			if (SG.sanity <= 0) {
				StartCoroutine ("Dying");
			}
		}*/

		//dans le cas ou je suis dans une énigme

		if (EnigmeActiveeMortSystemOn) {
			if (SG.sanity <= 0) {
				StartCoroutine ("DyingEnigma");

			}
		}

		if (preyMort) {
			if (SG.sanity <= 0) {
				StartCoroutine ("DyingPrey");

			}
		}

		if (tutoMort) {
			if (SG.sanity <= 0) {
				StartCoroutine ("DyingTuto");
			}
		}

		if (amIAtZero && goingUp) {
			ImageWhite.alpha += smoothWhiteBeginning;
		}

		if (amIAtMax && goingDown) {
			ImageWhite.alpha -= smoothWhiteBeginning;
		}

		if (ImageWhite.alpha <= 0) {
			amIAtZero = true;
		}

		if (ImageWhite.alpha >= 1) {
			amIAtMax = true;
		}
	}

	IEnumerator Dying () {
		goingUp = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingUp = false;
		Player.transform.position =  Artefact.transform.position + new Vector3 (1,0,1);
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = false;
	}

	IEnumerator DyingEnigma () {
		goingUp = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingUp = false;
		Player.transform.position =  RespawnEnigme.transform.position;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = false;
	}

	IEnumerator DyingTuto () {
		goingUp = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingUp = false;
		Player.transform.position =  RespawnTuto.transform.position;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = false;
	}

	IEnumerator DyingPrey () {
		goingUp = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingUp = false;
		Player.transform.position =  RespawnEnigmePrey.transform.position;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = true;
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		goingDown = false;
	}
}
