using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class SmallItem2: MonoBehaviour {

	private const int
	IDLE = 0,
	POSEARTEFACT = 1,
	GETBACKARTEFACT = 2,
	IDLEFIN = 4;

	public int state;

	public GameObject[] Mesh;
	GameObject 
	Player,
	colliders,
	ActivateCubes,
	artefactSurUI,
	CanvasItem2,
	ArtefactTutoAutelItem2;

	DetectableLocalManager DetectL;	
	GameManager GM;

	public string tag;
	float amout;
	float distance;
	public float Speed;

	bool didICheck = false;
	bool didIdoneThisonce = false;
	bool launch = false;
	bool stop;

	void Start () {
		ArtefactTutoAutelItem2 = GameObject.Find ("ArtefactTutoAutelItem2");
		ArtefactTutoAutelItem2.SetActive (false);
		CanvasItem2 = GameObject.Find ("CanvasItem2");
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		Player = GameObject.Find ("Player");
		Mesh = GameObject.FindGameObjectsWithTag (tag);
		DetectL = GameObject.Find("SmallItem2").GetComponent<DetectableLocalManager> ();
		colliders = GameObject.Find ("UI - Fresque_0");
		colliders.SetActive (false);
		amout = 1.0f;
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			Mesh [i].SetActive (false);
		}
		ActivateCubes = GameObject.Find ("ActivateCubeAutel");
		ActivateCubes.SetActive (false);

		StartCoroutine ("waitforIntro");

		state = IDLE;
	}

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}


	void Update (){

		distance = Vector3.Distance (transform.position, Player.transform.position);

		switch (state) {

		case IDLE:
			
			if (DetectL.isPlayerHere) {
				didICheck = true;
			}

			if (didICheck && distance < 10 && Input.GetButtonDown ("E")) {
				state = POSEARTEFACT;
			}

			break;

		case POSEARTEFACT:

			StartCoroutine ("appear");
			GM.DesactiverActionDisponibleLacherCube ();
			artefactSurUI.SetActive (false);
			ArtefactTutoAutelItem2.SetActive (true);
			launch = true;
			ActivateCubes.SetActive (true);
			state = GETBACKARTEFACT;
			break;

		case GETBACKARTEFACT:

			if (launch && !stop) {
				for (int i = 0; i < Mesh.Length; i++) {
					Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
				}
				amout -= 0.01f * Time.deltaTime * Speed;
				if (amout <= 0.0f) {
					stop = true;
				}
			}

			CanvasItem2.SetActive (false);

			if (Input.GetButtonDown ("E") && distance < 10) {
				ActivateCubes.transform.GetChild (3).gameObject.SetActive (false);
				ArtefactTutoAutelItem2.SetActive (false);
				artefactSurUI.SetActive (true);
				GM.DesactiverActionDisponibleLacherCube ();
				GM.DesactiverAnimSpeed ();
				StartCoroutine ("wait");
			}
		
			break;

		case IDLEFIN:

			this.gameObject.GetComponent<SmallItem2> ().enabled = false;

			break;
		}
	}

	IEnumerator appear () {
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].SetActive (true);
		}
		yield return new WaitForSeconds (3.0f);
		for (int i = 0; i < Mesh.Length; i++) {
			
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
		colliders.SetActive (true);
	}

	IEnumerator wait () {
		yield return new WaitForSeconds (5.0f);
		state = IDLEFIN;
	}
}
