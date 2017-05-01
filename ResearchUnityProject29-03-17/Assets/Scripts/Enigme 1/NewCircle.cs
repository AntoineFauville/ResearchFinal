using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NewCircle : MonoBehaviour {

	private const int 	
	PREIDLE = 0, //en idle avant que le joueur n'arrive
	IDLE = 1, //le joueur a appuyer sur espace
	ANIMINTRO = 2, //l'anim de jonction, le joueur place l'artefact
	BLOQUER = 3,  //bloquage temporaire, le joueur doit résoudre l'énigme
	RESOLUTION = 4, //l'énigme est résolue, l'anim montre le joueur reprendre l'artefact
	IDLEFIN = 5; // le totem est terminer et on ne sait plus y acceder.

	public int 
	state;

	public GameObject[]
	Circles;

	Animator
	AutelAnim,
	CubeTrigAnim,
	AnimDeFinAnimator;

	public int 
	templeRotationPart;

	float 
	amount = 1.0f;

	GameObject
	AutelPreTemple,
	AutelTemple,
	AutelAnimFin,
	Player,
	CanvasTemplePlacing,
	ArtefactTempl,
	CanvasTempleEnigme,
	MainCamera,
	CameraEnigme,
	CameraFinEnigmeCamera,
	Artefact;

	bool 
	autelGo,
	doOnce,
	notgoodyet,
	upAutel,
	AnimBoolAutelPlacing,
	amIOnTemple,
	returnAxisBool,
	Left,
	Right,
	goFin,
	DOONLYONCE,
	goanimFin;

	GameManager GM;
	DeathSystem DS;
	SanityGestion SG;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		MainCamera = GameObject.Find ("Main Camera Main");

		CameraEnigme = GameObject.Find ("CameraEnigmeTemple");
		CameraEnigme.GetComponent<Camera> ().enabled = false;

		AnimDeFinAnimator = GameObject.Find ("DoorRotationSystem").GetComponent<Animator> ();
		CameraFinEnigmeCamera = GameObject.Find ("CameraTempleFinEnigme");
		CameraFinEnigmeCamera.SetActive (false);

		CubeTrigAnim = GameObject.Find ("CubeTriggerTemple").GetComponent<Animator> ();

		Circles = GameObject.FindGameObjectsWithTag ("circle");
		ArtefactTempl = GameObject.Find("artefactTemple");
		AutelAnimFin = GameObject.Find("AnimationAutelFinTemple");
		ArtefactTempl.SetActive (false);

		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		DS = GameObject.Find ("ScriptManager").GetComponent<DeathSystem> ();
		SG = GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ();

		AutelAnim = GameObject.Find ("Autel Artefact Enigme Temple").GetComponent<Animator> ();

		AutelTemple = GameObject.Find ("Autel Artefact Enigme Temple");
		AutelPreTemple = GameObject.Find ("PRE Autel Artefact Enigme Temple");
		AutelTemple.SetActive (false);
		AutelPreTemple.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);

		CanvasTemplePlacing = GameObject.Find ("CanvasTemplePlace");
		CanvasTempleEnigme = GameObject.Find ("CanvasTempleEnigme");
		CanvasTempleEnigme.SetActive (false);
		CanvasTemplePlacing.SetActive (false);

		for (int i = 0; i < Circles.Length; i++) {
			Circles [i].gameObject.transform.GetChild (0).gameObject.SetActive (false);
		}
		StartCoroutine ("waitforIntro"); 
		StartCoroutine ("randomBegin");
	}

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (7.0f);
		Artefact = GameObject.Find ("ARtefactOverLayInteraction");
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance (this.gameObject.transform.position, Player.transform.position);

		if (!notgoodyet && upAutel) {
			AutelTemple.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);
			amount -= 0.01f * Time.deltaTime * 30;
			if (amount <= 0) {
				notgoodyet = true;
			}
		}

		if (autelGo && !DOONLYONCE) {
			AutelPreTemple.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);
			amount -= 0.01f * Time.deltaTime * 30;

			if (amount <= 0.3f) {
				AutelTemple.SetActive (true);
				AutelPreTemple.SetActive (false);
				DOONLYONCE = true;
			}
		}

		switch (state) {

		case PREIDLE:

			if (distance < 20 && !doOnce) {
				autelGo = true;
				doOnce = true;
			}



			if (distance < 10 && Input.GetButtonDown ("Submit")) {
				state = IDLE;
			}

			break;

		case IDLE:

			AutelTemple.GetComponent<goingUpDown> ().enabled = false;
			upAutel = true;

			CanvasTemplePlacing.SetActive (true);

			if (distance < 5 && Input.GetButtonDown ("E")) {
				CanvasTemplePlacing.SetActive (false);
				CanvasTempleEnigme.SetActive (true);
				DS.templeMort = true;
				Artefact.SetActive (false);
				state = ANIMINTRO;
			}

			break;

		case ANIMINTRO:

			StartCoroutine ("animIntro");

			break;

		case BLOQUER:

			if (Input.GetButtonDown ("E") && !amIOnTemple) {
				
				MainCamera.GetComponent<Camera> ().enabled = false;
				Player.GetComponent<FirstPersonController> ().enabled = false;
				CameraEnigme.GetComponent<Camera> ().enabled = true;

				CanvasTempleEnigme.SetActive (false);

				amIOnTemple = true;
				CubeTrigAnim.SetBool ("goUp", amIOnTemple);

			} else if (Input.GetButtonDown ("E") && amIOnTemple) {
				StartCoroutine ("waitforAnimCamera");

				amIOnTemple = false;
				CubeTrigAnim.SetBool ("goUp", amIOnTemple);

			}

			Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("right", Right);
			Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("left", Left);

			//monter
			if (amIOnTemple && (Input.GetAxis ("Vertical") > 0.05f || Input.GetButton ("Down")) && !returnAxisBool) {

				templeRotationPart--;

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}
			//descendre
			if (amIOnTemple && (Input.GetAxis ("Vertical") < -0.05f || Input.GetButton ("Up")) && !returnAxisBool) {

				templeRotationPart++;

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}
			//gauche
			if (amIOnTemple && (Input.GetAxis ("Horizontal") > 0.05f || Input.GetButton ("right")) && !returnAxisBool) {

				Left = true;
				StartCoroutine ("leftRightBack");

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}
			//droite
			if (amIOnTemple && (Input.GetAxis ("Horizontal") < -0.05f || Input.GetButton ("left")) && !returnAxisBool) {

				Right = true;
				StartCoroutine ("leftRightBack");

				returnAxisBool = true;
				StartCoroutine ("returnAxis");
			}

			if (templeRotationPart < 0) {
				templeRotationPart = Circles.Length - 1;
			}

			if (templeRotationPart > Circles.Length - 1) {
				templeRotationPart = 0;
			}

			Circles [templeRotationPart].gameObject.transform.GetChild (0).gameObject.SetActive (true);

			for (int i = 0; i < Circles.Length; i++) {

				if (i != templeRotationPart) {
					Circles [i].gameObject.transform.GetChild (0).gameObject.SetActive (false);
				}
			}
				

			if (
				//number 1
				(Circles [0].GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("TempleCircleDoor0-45") ||
					Circles [0].GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("TempleCircleDoor90-45")) &&
				//number 2
				(Circles [1].GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("TempleCircleDoor0-45") ||
					Circles [1].GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("TempleCircleDoor90-45")) &&
				//number 3
				(Circles [2].GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("TempleCircleDoor0-45") ||
					Circles [2].GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("TempleCircleDoor90-45"))
			) 
			{
				state = RESOLUTION;	
			}

			//resolution

			break;

		case RESOLUTION:

			AutelPreTemple.SetActive (false);
			AutelTemple.SetActive (false);

			CanvasTempleEnigme.SetActive (false);

			GM.DesactiverActionDisponibleLacherCube ();
			GM.DesactiverAnimSpeed ();
			DS.templeMort = false;

			StartCoroutine ("endingAnimation");


			break;

		case IDLEFIN:

			this.gameObject.GetComponent<NewCircle> ().enabled = false;

			break;
		}

	}

	IEnumerator animIntro (){

		ArtefactTempl.SetActive (true);
		AnimBoolAutelPlacing = true;
		AutelAnim.SetBool ("AnimTempleAutel",AnimBoolAutelPlacing);
		yield return new WaitForSeconds (2.0f);
		state = BLOQUER;

	}

	IEnumerator returnAxis(){
		yield return new WaitForSeconds (0.5f);
		returnAxisBool = false;
	}

	IEnumerator leftRightBack(){
		yield return new WaitForSeconds (0.5f);	
		Right = false;
		Left = false;
	}

	IEnumerator waitforAnimCamera(){
		yield return new WaitForSeconds (2.0f);
		MainCamera.GetComponent<Camera> ().enabled = true;
		Player.GetComponent<FirstPersonController> ().enabled = true;
		CameraEnigme.GetComponent<Camera> ().enabled = false;
		CanvasTempleEnigme.SetActive (true);
	}

	IEnumerator endingAnimation(){
		yield return new WaitForSeconds (1.0f);

		Left = false;
		Right = false;
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("right", Right);
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("left", Left);

		//ramene la camera
		amIOnTemple = false;
		CubeTrigAnim.SetBool ("goUp", amIOnTemple);
		yield return new WaitForSeconds (2.0f);
		//temps poour la camera
		//active le joueur back
		MainCamera.GetComponent<Camera> ().enabled = true;
		Player.GetComponent<FirstPersonController> ().enabled = true;
		CameraEnigme.GetComponent<Camera> ().enabled = false;
		//lance l'animation et le reste
		AutelTemple.SetActive (false);
		goFin = true;
		AutelAnimFin.GetComponent<Animator> ().SetBool ("goFinTotem", goFin);
		GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ().sanity = 1.0f;



		yield return new WaitForSeconds (8.0f);
		Artefact.SetActive (true);
		goanimFin = true;
		AnimDeFinAnimator.SetBool("goAnimFinCamera",goanimFin);

		MainCamera.GetComponent<Camera> ().enabled = false;
		Player.GetComponent<FirstPersonController> ().enabled = false;

		CameraFinEnigmeCamera.SetActive (true);


		yield return new WaitForSeconds (7.0f);
		CameraFinEnigmeCamera.GetComponent<Camera> ().enabled = false;
		MainCamera.GetComponent<Camera> ().enabled = true;
		Player.GetComponent<FirstPersonController> ().enabled = true;
		state = IDLEFIN;
	
	}

	IEnumerator randomBegin (){
		templeRotationPart = Random.Range(0, Circles.Length);
		Right = true;
		Left = true;
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("right", Right);
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("left", Left);
		yield return new WaitForSeconds (4.0f);
		templeRotationPart = Random.Range(0, Circles.Length);
		Right = true;
		Left = true;
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("right", Right);
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("left", Left);
		yield return new WaitForSeconds (4.0f);
		templeRotationPart = Random.Range(0, Circles.Length);
		Right = true;
		Left = true;
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("right", Right);
		Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("left", Left);
		yield return new WaitForSeconds (4.0f);
		templeRotationPart = 0;
		Right = false;
		Left = false;
		for (int i = 0; i < Circles.Length; i++) {
			Circles [i].GetComponent<Animator> ().SetBool ("right", Right);
			Circles [i].GetComponent<Animator> ().SetBool ("left", Left);
		}

		for (int i = 0; i < Circles.Length; i++) {
			if (Circles [i].gameObject.transform.rotation.eulerAngles.z == 45) {
				templeRotationPart = 0;
				Right = true;
				Circles [templeRotationPart].GetComponent<Animator> ().SetBool ("right", Right);
			}
		}

		yield return new WaitForSeconds (1.0f);
	}
}
