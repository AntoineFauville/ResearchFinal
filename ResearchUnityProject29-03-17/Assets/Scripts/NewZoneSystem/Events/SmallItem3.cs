using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class SmallItem3 : MonoBehaviour {

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
	artefactSurUI;

	GameManager GM;
	DetectableLocalManager DetectL;

	Animator anim;

	public string tag;
	float amout;
	float distance;
	public float Speed;

	bool didICheck = false;
	bool launch = false;
	bool stop;

	void Start () {
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
	
		state = IDLE;
	}

	IEnumerator waitforIntro(){
		yield return new WaitForSeconds (6.0f);
		artefactSurUI =  GameObject.Find ("animartefact_1");
	}

	void Update (){

		switch (state) {

		case IDLE:

			distance = Vector3.Distance (transform.position, Player.transform.position);
		
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

			if (launch && !stop) {
				for (int i = 0; i < Mesh.Length; i++) {
					Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
				}
				amout -= 0.01f * Time.deltaTime * Speed;
				if (amout <= 0.0f) {
					stop = true;
				}
			}

			GameObject.Find ("CanvasItem3").SetActive (false);
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
	}

	IEnumerator wait () {
		yield return new WaitForSeconds (5.0f);
		state = IDLEFIN;
	}
}
