using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;


public class AppearVillage : MonoBehaviour {

	public GameObject[] tutoMesh;

	DetectableLocalManager DetectL;
	public string tag;
	float amout; 
	public float Speed;

	bool doOnce;
	bool stop, go;

	// Use this for initialization
	void Start () {
		tutoMesh = GameObject.FindGameObjectsWithTag (tag);
		DetectL = this.gameObject.GetComponent<DetectableLocalManager> ();

		amout = 1.0f;
		for (int i = 0; i < tutoMesh.Length; i++) {
			tutoMesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			tutoMesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			tutoMesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			tutoMesh [i].SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(DetectL.isPlayerHere){
			go = true;
		}

		if (go && !stop) {
			if (!doOnce) {
				StartCoroutine ("appear");
				doOnce = true;
			}
			for (int i = 0; i < tutoMesh.Length; i++) {
				tutoMesh [i].SetActive (true);
				tutoMesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}
			amout -= 0.01f * Time.deltaTime * Speed;

			if (amout <= 0.0f) {
				stop = true;
			}
		}


	}

	IEnumerator appear () {
		yield return new WaitForSeconds (3.0f);
		for (int i = 0; i < tutoMesh.Length; i++) {
			tutoMesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			tutoMesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
	}
}
