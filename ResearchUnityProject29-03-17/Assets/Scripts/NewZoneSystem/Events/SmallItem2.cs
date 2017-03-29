using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class SmallItem2: MonoBehaviour {

	public GameObject[] Mesh;
	GameObject Player;
	GameObject colliders;

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
	}

	void Update (){

		if (!didIdoneThisonce) {
			distance = Vector3.Distance (transform.position, Player.transform.position);
		}

		if (DetectL.isPlayerHere) {
			didICheck = true;
		}

		if (didICheck && distance < 10 && Input.GetButtonDown("Submit") && !didIdoneThisonce) {
			didIdoneThisonce = true;
			StartCoroutine ("appear");
			GM.DesactiverActionDisponibleLacherCube ();
			launch = true;
		}

		if (launch && !stop) {
			for (int i = 0; i < Mesh.Length; i++) {
				Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}
			amout -= 0.01f * Time.deltaTime * Speed;
			if (amout <= 0.0f) {
				stop = true;
			}
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
}
