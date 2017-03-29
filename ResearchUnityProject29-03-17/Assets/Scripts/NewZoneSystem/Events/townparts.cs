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
	bool stop;
	bool go;
	public float Speed = 20.0f;

	public bool didICheck = false;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");

		Mesh = GameObject.FindGameObjectsWithTag (tag);
		DetectL = GameObject.Find("Town1").GetComponent<DetectableLocalManager> ();

		amout = 1.0f;
		for (int i = 0; i < Mesh.Length; i++) {
			
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);

			Mesh [i].SetActive (false);
		}
	}


	void Update (){
		float distance = Vector3.Distance (transform.position, Player.transform.position);

		if (DetectL.isPlayerHere) {
			go = true;
		}

		if (go && distance < 30) {
			didICheck = true;
		}

		if (didICheck && !stop) {
			StartCoroutine ("appear");
			for (int i = 0; i < Mesh.Length; i++) {
				Mesh [i].SetActive (true);
				Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}
			amout -= 0.01f * Time.deltaTime * Speed;
		}
		if (amout <= 0.0f) {
			stop = true;
		}
	}

	IEnumerator appear () {
		yield return new WaitForSeconds (3.0f);
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
	}
}
