using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Area2Part1 : MonoBehaviour {

	public GameObject[] Area2Part1Object;
	public string tag;

	float amout;
	bool stop;
	public float Speed = 5.0f;

	bool playerisHere;


	// Use this for initialization
	void Start () {
		Area2Part1Object = GameObject.FindGameObjectsWithTag (tag);

		amout = 1.0f;

		for (int i = 0; i < Area2Part1Object.Length; i++) {

			Area2Part1Object [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Area2Part1Object [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Area2Part1Object [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amounts", amout);

			Area2Part1Object [i].SetActive (false);

			//StartCoroutine ("update");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (playerisHere && !stop) {
			for (int i = 0; i < Area2Part1Object.Length; i++) {
				Area2Part1Object [i].SetActive (true);
				Area2Part1Object [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}
			amout -= 0.01f * Time.deltaTime * Speed;

			if(amout <= 0.0f){
				stop = true;
			}
		}
	}

	IEnumerator appear () {
		yield return new WaitForSeconds (3.0f);
		for (int i = 0; i < Area2Part1Object.Length; i++) {
			Area2Part1Object [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			Area2Part1Object [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
	}

	void OnTriggerEnter (Collider col) {
		if (col.tag == "Player") {
			playerisHere = true;
		}
		
	}
}
