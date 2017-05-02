using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class SmallItem4 : MonoBehaviour {

	private const int
	IDLEPRE = 0,
	IDLE = 1,
	POSEARTEFACT = 2,
	GETBACKARTEFACT = 3,
	IDLEFIN = 4;

	public int state;

	public GameObject[] Mesh;
	GameObject 
	Player,
	artefactSurUI,
	canvasItem,
	autel,
	SmallItem4blue;

	GameManager GM;
	DetectableLocalManager DetectL;

	Animator anim;

	public string tag;
	float amout,
	amount;
	float distance;
	public float Speed;

	bool 
	didICheck,
	launch,
	stop, 
	go,
	checkOnce,
	startAutel,
	stop2;


	void Start () {
		canvasItem = GameObject.Find ("CanvasIdolationPlace");
		canvasItem.SetActive (false);
	
		Player = GameObject.Find ("Player");

		SmallItem4blue = GameObject.Find ("SmallItem4blue");

		autel = GameObject.Find ("AutelIdolation");

		anim = autel.GetComponent<Animator> ();
		Mesh = GameObject.FindGameObjectsWithTag (tag);

		DetectL = GameObject.Find("SmallItem4").GetComponent<DetectableLocalManager> ();
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();

		amout = 1.0f;
		amount = 1.0f;

		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			Mesh [i].SetActive (false);
		}

		autel.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);

		StartCoroutine ("waitforIntro");

		state = IDLEPRE;
	}

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}

	void FixedUpdate (){

		if (launch && !stop) {
			for (int i = 0; i < Mesh.Length; i++) {
				Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}
			amout -= 0.01f * Time.deltaTime * Speed;
			if (amout <= 0.0f) {
				stop = true;
			}
		}

		distance = Vector3.Distance (transform.position, Player.transform.position);

		switch (state) {

		case IDLEPRE:

			if (DetectL.isPlayerHere && distance < 20 && Input.GetButtonDown ("Submit")) {
				autel.GetComponent<goingUpDown> ().enabled = true;
				canvasItem.SetActive (true);
				state = IDLE;
			}

			break;

		case IDLE:

			autel.GetComponent<goingUpDown> ().enabled = false;
			autel.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amount);
			autel.GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			autel.GetComponent<MeshRenderer> ().receiveShadows = true;
			amount = 0.0f;

			if (distance < 10 && Input.GetButtonDown("E")) {
				
				StartCoroutine ("PoserArtefact");
			}

			break;

		case POSEARTEFACT:
			
			GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ().sanity = 1.0f;
			GM.DesactiverActionDisponibleLacherCube ();
			GM.DesactiverAnimSpeed ();

			SmallItem4blue.GetComponent<goingUpDown> ().enabled = false;
			SmallItem4blue.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", 0.0f);

			state = IDLEFIN;
			break;

		case IDLEFIN:
			
			StartCoroutine ("End");
			break;
		}
	}

	IEnumerator PoserArtefact () {
		artefactSurUI.SetActive (false);
		canvasItem.SetActive (false);
		go = true;
		anim.SetBool ("smallItemPreGo", go);
		yield return new WaitForSeconds (1.0f);
		launch = true;
		artefactSurUI.SetActive (true);

		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].SetActive (true);
		}
		yield return new WaitForSeconds (3.0f);

		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
		yield return new WaitForSeconds (1.0f);

		state = POSEARTEFACT;
	}

	IEnumerator End () {
		yield return new WaitForSeconds (10.0f);
		this.gameObject.GetComponent<SmallItem4> ().enabled = false;
	}
}
