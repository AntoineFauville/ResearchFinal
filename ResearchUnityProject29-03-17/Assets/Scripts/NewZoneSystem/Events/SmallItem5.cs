using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallItem5 : MonoBehaviour {

	GameManager GM;
	DetectableLocalManager DetectL;

	bool didIdoneThisonce,didICheck,launch;

	Animator anim;

	GameObject artefactSurUI, Player;

	float distance;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		DetectL = GameObject.Find("SmallItem5").GetComponent<DetectableLocalManager> ();
		anim = GameObject.Find ("AnimationSI5").GetComponent<Animator> ();

		StartCoroutine ("waitforIntro");
	}

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}
	
	// Update is called once per frame
	void Update () {
		if (!didIdoneThisonce) {
			distance = Vector3.Distance (transform.position, Player.transform.position);
		}

		if (DetectL.isPlayerHere) {
			didICheck = true;
		}

		if (didICheck && distance < 10 && Input.GetButtonDown("Submit") && !didIdoneThisonce) {
			didIdoneThisonce = true;
			StartCoroutine ("appear5");
			artefactSurUI.SetActive (false);
			launch = true;
			anim.SetBool ("caveAnimgo",launch);
		}
	}

	IEnumerator appear5 () {
		yield return new WaitForSeconds (3.0f);
		artefactSurUI.SetActive (true);
		GM.DesactiverActionDisponibleLacherCube ();
	}
}
