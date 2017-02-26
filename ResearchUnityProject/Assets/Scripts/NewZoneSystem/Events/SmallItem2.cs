using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class SmallItem2: MonoBehaviour {

	public GameObject[] Mesh;
	GameObject Player;
	GameObject colliders;

	DetectableLocalManager DetectL;
	public string tag;
	float amout;
	float distance;

	bool didICheck = false;
	bool didIdoneThisonce = false;
	bool launch = false;

	void Start () {
		Player = GameObject.Find ("Player");
		Mesh = GameObject.FindGameObjectsWithTag (tag);
		DetectL = GameObject.Find("SmallItem2").GetComponent<DetectableLocalManager> ();
		colliders = GameObject.Find ("UI - Fresque_0");
		colliders.SetActive (false);
		amout = 1.0f;
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_DissolvePercentage", amout);
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
			launch = true;
		}

		if (launch) {
			for (int i = 0; i < Mesh.Length; i++) {
				Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_DissolvePercentage", amout);
			}
			amout -= 0.01f;
		}
	}

	IEnumerator appear () {
		yield return new WaitForSeconds (3.0f);
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
		colliders.SetActive (true);
	}
}
