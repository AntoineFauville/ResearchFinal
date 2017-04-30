using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[SerializeField]
public class ObjWithDescription : MonoBehaviour {

	private const int
	IdleBeforeDiscovery = 0,
	IdleWhendiscovered = 1;

	GameObject[] Mesh;
	public string tag;
	float amout;
	public float Speed;

	GameObject
	Player;

	public int state;

	public Animator
	AnimatorCanvasObj;

	public bool
	goingUp,
	PlayerIsAround;


	//isthere special item to activate only after ?
	public bool special;

	public GameObject[] SpecialMesh;

	// Use this for initialization
	void Start () {

		Mesh = GameObject.FindGameObjectsWithTag (tag);

		amout = 1.0f;
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = false;
			Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
		}
		if (special) {
			for (int i = 0; i < SpecialMesh.Length; i++) {
				SpecialMesh [i].SetActive (false);
			}
		}

		Player = GameObject.Find ("Player");
		state = IdleBeforeDiscovery;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		switch (state) {
			
		case IdleBeforeDiscovery:
			

			if(Input.GetButtonDown("Submit")){
				StartCoroutine ("waitHalfSecBeforeIdle");
			}


			if (amout < 0.7f && goingUp) {
				amout += 0.01f * Time.deltaTime * Speed;
			} 

			if (amout >= 0.7f && goingUp) {
				goingUp = false;
			}

			if (amout > 0.3f && !goingUp) {
				amout -= 0.01f * Time.deltaTime * Speed;
			} 

			if (amout <= 0.3f && !goingUp) {
				goingUp = true;
			}

			for (int i = 0; i < Mesh.Length; i++) {
				Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}

			break;

		case IdleWhendiscovered:
			
			if (amout >= 0) {
				amout -= 0.01f * Time.deltaTime * Speed;
			}

			for (int i = 0; i < Mesh.Length; i++) {
				Mesh [i].GetComponent<MeshRenderer> ().material.SetFloat ("_Amount", amout);
			}


			float distance = Vector3.Distance (Player.transform.position, this.gameObject.transform.position);

			if (distance < 10) {
				PlayerIsAround = true;
			} else {
				PlayerIsAround = false;
			}

			AnimatorCanvasObj.SetBool ("GetActiveBool", PlayerIsAround);

			break;
		}
	}

	IEnumerator waitHalfSecBeforeIdle () {
		yield return new WaitForSeconds (0.5f);
		state = IdleWhendiscovered;
		yield return new WaitForSeconds (2.0f);
		for (int i = 0; i < Mesh.Length; i++) {
			Mesh [i].GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.On;
			Mesh [i].GetComponent<MeshRenderer> ().receiveShadows = true;
		}
		if (special) {
			for (int i = 0; i < SpecialMesh.Length; i++) {
				SpecialMesh [i].SetActive (true);
			}
		}
	}
}
