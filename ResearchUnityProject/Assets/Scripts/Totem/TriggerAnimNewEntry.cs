using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimNewEntry : MonoBehaviour {

	Animator Anim;

	bool walkedIn;
	bool firstTimeWalkedIn = false;

	public GameObject ImageIllu01;
	//GameObject ImageIllu02;

	//public bool isItImage01;
	//public bool isItImage02;

	// Use this for initialization
	void Start () {
		Anim = GameObject.Find ("Panel New Entry Totem").GetComponent<Animator> ();
		//ImageIllu01 = GameObject.Find ("ButtonImageBouquinTotemIllu01");
		//ImageIllu02 = GameObject.Find ("ButtonImageBouquinTotemIllu02");
		ImageIllu01.SetActive (false);
		//ImageIllu02.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider Coll){
		if (Coll.tag == "Player" && !firstTimeWalkedIn) {
			Anim.SetBool ("Image",walkedIn);
			firstTimeWalkedIn = true;
			StartCoroutine ("returnBool");

			/*if (isItImage01) {*/
				ImageIllu01.SetActive (true);/*
			} else if (isItImage02) {
				ImageIllu02.SetActive (true);
			}*/
		}
	}

	IEnumerator returnBool () {
		walkedIn = true;
		Anim.SetBool ("Image",walkedIn);
		yield return new WaitForSeconds (0.2f);
		walkedIn = false;
		Anim.SetBool ("Image",walkedIn);
	}
}
