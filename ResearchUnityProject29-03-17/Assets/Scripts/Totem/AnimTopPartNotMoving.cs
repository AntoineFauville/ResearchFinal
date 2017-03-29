using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTopPartNotMoving : MonoBehaviour {

	Animator anim;

	bool gauche;
	bool droite;

	public bool canIUseHorizontalAgain = false;
	public bool amITurningRight = false;
	public bool amITurningLeft = false;

	public bool canIturnAgain = false;

	public bool canIUseIt = false;

	// Use this for initialization
	void Start () {
		anim = GameObject.Find ("TopPartTotem").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Gauche",gauche);
		anim.SetBool ("Droite",droite);




		if (Input.GetAxis("Horizontal") > 0.2 && canIUseHorizontalAgain == false && canIUseIt) {
			canIUseHorizontalAgain = true;
			droite = true;
			StartCoroutine ("returnBool");
		}

		if (Input.GetAxis("Horizontal") < -0.2 && canIUseHorizontalAgain == false && canIUseIt) {
			canIUseHorizontalAgain = true;
			gauche = true;
			StartCoroutine ("returnBool");
		}
	}

	IEnumerator returnBool(){
		yield return new WaitForSeconds (0.4f);
		gauche = false;
		droite = false;
		canIUseHorizontalAgain = false;
	}
}
