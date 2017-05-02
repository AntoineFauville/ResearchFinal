using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Rendering;

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

	public bool 
		startAppear,
		animation,
		doThisOnce;

	public float 
		secondstoWait,
		amount;

	//parametre d'animation
	public Animator anim;

	GameObject 
		Player, 
		MainCamera,
		artefactSurFesses,
		artefactTuto,
		artefactSurUI,
		AutelBeforeTuto,
		AutelAnimationTuto,
		SmallItem1Blue;

	DeathSystem DS;

	// Use this for initialization
	void Start () {

		DS = GameObject.Find ("ScriptManager").GetComponent<DeathSystem> ();

		SmallItem1Blue = GameObject.Find ("SmallItem1blue");

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

		AutelBeforeTuto.SetActive (true);

		amount = 1.0f;

		AutelBeforeTuto.GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
		AutelBeforeTuto.GetComponent<MeshRenderer> ().receiveShadows = false;
		AutelBeforeTuto.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);

		AutelBeforeTuto.SetActive (false);
		AutelAnimationTuto.SetActive (false);

		state = AVANT;
	}
	

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}


	void FixedUpdate () {
		switch (state) {

		case AVANT:

			if (DLM.isPlayerHere && !doThisOnce) {
				startAppear = true;
				doThisOnce = true;
			}

			if (startAppear) {
				StartCoroutine ("Appear");
				AutelBeforeTuto.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);
				amount -= 0.01f * Time.deltaTime * 30;
			}


			//l'objet glitch
			
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
				DS.tutoMort = true;
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

			SmallItem1Blue.GetComponent<goingUpDown> ().enabled = false;
			SmallItem1Blue.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", 0.0f);

			GameObject.Find ("Autel Artefact tuto").GetComponent<GlowObject> ().enabled = false;

			animation = false;
			image.SetBool ("Ping", animation);

			state = FINIDLE;

			break;

		case FINIDLE:

		break;

		}
	}

	IEnumerator Appear (){
		
		AutelBeforeTuto.SetActive (true);
		AutelBeforeTuto.GetComponent<goingUpDown> ().enabled = false;
		AutelBeforeTuto.GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
		AutelBeforeTuto.GetComponent<MeshRenderer> ().receiveShadows = false;

		yield return new WaitForSeconds (4.0f);

		startAppear = false;

		AutelBeforeTuto.GetComponent<goingUpDown> ().enabled = true;
	}
}
