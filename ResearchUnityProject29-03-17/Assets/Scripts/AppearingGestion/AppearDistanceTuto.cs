using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine;


public class AppearDistanceTuto : MonoBehaviour {

	public GameObject[] tutoMesh;

	DetectableLocalManager DetectL;
	GameManager GM;
	public string tag;
	float amout;
	public float Speed;

	bool playerwent,
	stop,
	doOnce,
	appearEvent;

	public bool isThisSmallItem4;

	// Use this for initialization
	void Start () {
		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager> ();
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
		if (DetectL.isPlayerHere) {
			playerwent = true;
		}
		if(playerwent && appearEvent && !stop) {
			if (!doOnce) {
				StartCoroutine ("appear");
				doOnce = true;
			}
			if (isThisSmallItem4) {
				GM.DesactiverActionDisponibleLacherCube ();
			}
			for (int i = 0; i < tutoMesh.Length; i++) {
				tutoMesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}
			amout -= 0.01f * Time.deltaTime * Speed;

			if (amout <= 0.0f) {
				stop = true;
			}
		}
	}

	IEnumerator appear () {
		for (int i = 0; i < tutoMesh.Length; i++) {
		tutoMesh [i].SetActive (true);
		}
		yield return new WaitForSeconds (3.0f);
		for (int i = 0; i < tutoMesh.Length; i++) {
			
			tutoMesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			tutoMesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
	}
}
