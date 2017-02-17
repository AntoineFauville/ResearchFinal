using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNextObjective : MonoBehaviour {
	/*
	public Animator anim1;
	public bool anim1Bool;
	public Animator anim2;
	public bool anim2Bool;

	public Animator playerCanvasUI;
	public bool newObjectivePlayerUI;

	public bool didPlayerEnter;
	public bool firstTimeEnter;

	public GameObject lastCheckObjectiveBox;

	void Start () {
		anim1Bool = false;
		anim2Bool = false;
		newObjectivePlayerUI = false;
		anim1.SetBool ("NewObjective",anim1Bool);
		anim2.SetBool ("NewObjective",anim2Bool);
		playerCanvasUI.SetBool ("NewObjectiveActiv",newObjectivePlayerUI);
	}

	void Update () {
		anim1.SetBool ("NewObjective",anim1Bool);
		anim2.SetBool ("NewObjective",anim2Bool);
		playerCanvasUI.SetBool ("NewObjectiveActiv",newObjectivePlayerUI);

		if (didPlayerEnter) {
			
			anim1Bool = false;
			anim2Bool = true;

			StartCoroutine ("returnAfterOneSec");
			didPlayerEnter = false;
			lastCheckObjectiveBox.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.tag == "Player" && !firstTimeEnter) {
			didPlayerEnter = true;
			firstTimeEnter = true;
		}
	}

	IEnumerator returnAfterOneSec () {
		newObjectivePlayerUI = true;
		yield return new WaitForSeconds (0.5f);
		newObjectivePlayerUI = false;
	}*/
}