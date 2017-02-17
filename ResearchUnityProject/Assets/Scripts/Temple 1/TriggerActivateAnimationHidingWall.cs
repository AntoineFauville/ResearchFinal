using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivateAnimationHidingWall : MonoBehaviour {

	public GameObject cam1;
	public GameObject cam2;
	public GameObject player;

	public Animator anim;
	public bool vibrateAnim;

	bool passed;

	bool playerIsHere;

	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("Vibrate",vibrateAnim);

		if(playerIsHere && !passed){
			passed = true;
			StartCoroutine ("returnBool");	
		}
	}

	void OnTriggerEnter (Collider coll) {
		if(coll.tag == "Player"){
			playerIsHere = true;	
		}
	}

	IEnumerator returnBool(){
		vibrateAnim = true;
		cam1.SetActive (false);
		cam2.SetActive (true);
		player.SetActive (false);

		yield return new WaitForSeconds (0.5f);
		vibrateAnim = false;
		yield return new WaitForSeconds (3.0f);
		cam1.SetActive (true);
		cam2.SetActive (false);
		player.SetActive (true);

	}
}
