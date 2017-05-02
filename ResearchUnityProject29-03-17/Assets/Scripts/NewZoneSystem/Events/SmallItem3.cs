using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class SmallItem3 : MonoBehaviour {

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
	colliders,
	artefactSurUI,
	canvasItem,
	SmallItem3blue;

	GameManager GM;
	DetectableLocalManager DetectL;

	Animator anim;

	public string tag;
	float amout;
	float distance;
	public float Speed;

	bool didICheck = false;
	bool launch = false;
	bool stop, go;


	void Start () {
		canvasItem = GameObject.Find ("CanvasItem3");
		SmallItem3blue = GameObject.Find ("SmallItem3blue");
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
		Player = GameObject.Find ("Player");
		anim = GameObject.Find ("SmallItem3Object").GetComponent<Animator> ();
		Mesh = GameObject.FindGameObjectsWithTag (tag);
		DetectL = GameObject.Find("SmallItem3").GetComponent<DetectableLocalManager> ();
		colliders = GameObject.Find ("SmallItem3Colliders");
		colliders.SetActive (false);
		amout = 1.0f;
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			Mesh [i].SetActive (false);
		}
		StartCoroutine ("waitforIntro");
	
		state = IDLEPRE;
	}

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}

	void Update (){

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
				go = true;
				anim.SetBool ("smallItemPreGo", go);
				state = IDLE;
			}

			break;

		case IDLE:
			
			if (DetectL.isPlayerHere) {
				didICheck = true;
			}

			if (didICheck && distance < 10 && Input.GetButtonDown("E")) {
				state = POSEARTEFACT;
			}

			break;

		case POSEARTEFACT:
			
			StartCoroutine ("appear");
			artefactSurUI.SetActive (false);
			launch = true;
			anim.SetBool ("ActivateSmallItem2", launch);
			state = GETBACKARTEFACT;
			break;

		case GETBACKARTEFACT:



			canvasItem.SetActive (false);
			StartCoroutine ("wait");

			break;

		case IDLEFIN:

			this.gameObject.GetComponent<SmallItem3> ().enabled = false;

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
		artefactSurUI.SetActive (true);

		GM.DesactiverActionDisponibleLacherCube ();
		GM.DesactiverAnimSpeed ();

		SmallItem3blue.GetComponent<goingUpDown> ().enabled = false;
		SmallItem3blue.GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", 0.0f);
	}

	IEnumerator wait () {
		yield return new WaitForSeconds (5.0f);
		GameObject.Find ("ScriptManager").GetComponent<SanityGestion> ().sanity = 1.0f;
		state = IDLEFIN;
	}
}
