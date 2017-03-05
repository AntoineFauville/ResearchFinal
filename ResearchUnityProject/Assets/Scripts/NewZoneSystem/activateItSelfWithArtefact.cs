using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateItSelfWithArtefact : MonoBehaviour {

	public GameObject Artefact;

	Animator anim;
	bool animBool;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("PanelArtefact").GetComponent<Animator> ();
	}
		

	// Update is called once per frame
	void Update () {
		if (Artefact.activeSelf == true) {
			animBool = true;
		} else if (Artefact.activeSelf == false) {
			animBool = false;
		}
		anim.SetBool ("ActivateSupport",animBool);
	}
}
