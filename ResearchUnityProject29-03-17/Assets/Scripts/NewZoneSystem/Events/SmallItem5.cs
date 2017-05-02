using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallItem5 : MonoBehaviour {

	GameManager GM;
	DetectableLocalManager DetectL;
	DeathSystem DS;
	SanityGestion SG;

	private const int 	
	IDLEBEFORE = 0, // before the player gets nearby also detect if player come around
	IDLE = 1, // player pressed space and appeared the base
	PRESSE = 2, //player pressed e to place the artefact
	ANIMATION = 3, //plays animation when player placed
	BLOCKED = 4, // animation done, the player needs to pick up by activating the water
	WATER = 5, //the water flows
	BLOCKED2 = 6, //the player can come and take his artefact back
	IDLEEND = 7; //the end

	public int 
	state;

	bool 
	didIdoneThisonce,
	didICheck,
	launch,
	AutelGo,
	DoOnce,
	didIcheck;

	Animator 
	anim;

	GameObject 
	artefactSurUI, 
	Player,
	AutelCave,
	canvasBlocked,
	canvasPlace,
	Lever,
	artefactSmallitem5,
	SmallItem5blue;

	float 
	distance,
	distance2,
	amount;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		DS = GameObject.Find ("ScriptManager").GetComponent<DeathSystem> ();
		SG = GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ();

		SmallItem5blue = GameObject.Find ("SmallItem5blue");

		DetectL = GameObject.Find("SmallItem5").GetComponent<DetectableLocalManager> ();
		anim = GameObject.Find ("AnimationSI5").GetComponent<Animator> ();

		canvasBlocked = GameObject.Find ("CanvasCaveBlocked");
		canvasPlace = GameObject.Find ("CanvasCavePlace");

		artefactSmallitem5 = GameObject.Find ("ArtefactSmallItem5");
		artefactSmallitem5.SetActive (false);

		Lever =  GameObject.Find ("LeverReference");

		canvasBlocked.SetActive (false);
		canvasPlace.SetActive (false);

		StartCoroutine ("waitforIntro");

		AutelCave = GameObject.Find ("Deuxieme Autel Cave");	

		AutelCave.SetActive (true);

		state = IDLEBEFORE;
	}

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}
	
	// Update is called once per frame
	void Update () {

		distance = Vector3.Distance (transform.position, Player.transform.position);

		distance2 = Vector3.Distance (Lever.transform.position, Player.transform.position);


		if (AutelGo && !DoOnce) {
			AutelCave.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);
			amount -= 0.01f * Time.deltaTime * 30;

			if (amount <= 0.3f) {
				DoOnce = true;
			}
		}

		switch (state) {

		case IDLEBEFORE:
			
			if (distance < 10 && Input.GetButtonDown ("Submit")) {
				canvasPlace.SetActive (true);
				state = IDLE;
			}

			break;

		case IDLE:

			AutelCave.GetComponent<goingUpDown> ().enabled = false;

			AutelGo = true;

			if (distance < 10 && Input.GetButtonDown ("E")) {
				DS.templeCave = true;
				artefactSurUI.SetActive (false);
				canvasPlace.SetActive (false);
				state = ANIMATION;
			}

			break;
		case ANIMATION:

			launch = true;
			anim.SetBool ("caveAnimgo", launch);
			state = BLOCKED;

			break;
		case BLOCKED:
			canvasBlocked.SetActive (true);
			if (distance2 < 5 && Input.GetButtonDown ("E")) {
				
				state = WATER;
			}

			break;
		case WATER:
			
			launch = false;
			anim.SetBool ("caveAnimgo", launch);
			artefactSmallitem5.SetActive (true);

			state = BLOCKED2;

			break;

		case BLOCKED2:

			if (distance < 5 && Input.GetButtonDown ("E")) {
				canvasBlocked.SetActive (false);
				DS.templeCave = false;
				artefactSmallitem5.GetComponent<MeshRenderer> ().enabled = false;
				artefactSmallitem5.GetComponent<LosingSanityWhenGettingAway> ().enabled = false;
				artefactSurUI.SetActive (true);
				GM.DesactiverActionDisponibleLacherCube ();
				GM.DesactiverAnimSpeed ();
				SG.sanity = 1.0f;

				SmallItem5blue.GetComponent<goingUpDown> ().enabled = false;
				SmallItem5blue.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", 0.0f);

				state = IDLEEND;
			}

			break;

		case IDLEEND:



			break;
		}
	}
}
