using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;

public class townparts : MonoBehaviour {

	public GameObject[] Mesh;

	GameObject Player;

	DetectableLocalManager DetectL;
	public string tag;
	float amout;

	bool didICheck = false;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");

		Mesh = GameObject.FindGameObjectsWithTag (tag);
		DetectL = GameObject.Find("Town1").GetComponent<DetectableLocalManager> ();

		amout = 1.0f;
		for (int i = 0; i < Mesh.Length; i++) {
			
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_DissolvePercentage", amout);

			Mesh [i].SetActive (false);

			//StartCoroutine ("update");
		}
	}


	void Update (){
		//yield return new WaitForSeconds (0.2f);
		float distance = Vector3.Distance (transform.position, Player.transform.position);

		if (DetectL.isPlayerHere) {
			didICheck = true;
		}

		if (didICheck && distance < 15) {
			StartCoroutine ("appear");
			for (int i = 0; i < Mesh.Length; i++) {
				Mesh [i].SetActive (true);
				Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_DissolvePercentage", amout);
			}
			amout -= 0.01f;
		}
		//StartCoroutine ("update");
	}

	IEnumerator appear () {
		yield return new WaitForSeconds (3.0f);
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
	}
}
