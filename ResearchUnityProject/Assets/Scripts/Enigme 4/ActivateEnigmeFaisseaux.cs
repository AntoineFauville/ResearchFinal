using UnityEngine;
using System.Collections;

public class ActivateEnigmeFaisseaux : MonoBehaviour {

	public bool playerIsHere = false;
	public bool amIOn = false;

	public GameObject player;
	public GameObject playerWrong;
	public GameObject cam1;
	public GameObject cam2;

	public GestionSelectionParts GSP;

	void Update () {

		if (!amIOn && playerIsHere && Input.GetButtonDown ("Submit")) {
			amIOn = true;
			player.SetActive (false);
			playerWrong.SetActive (true);
			cam1.SetActive (false);
			cam2.SetActive (true);

			GSP.state1 = true;
			GSP.state2 = false;
			GSP.state3 = false;
			GSP.OutlineDown.SetActive (true);
			GSP.OutlineMid.SetActive (false);
			GSP.OutlineTop.SetActive (false);

		} else if (amIOn && playerIsHere && Input.GetButtonDown ("Submit")) {
			amIOn = false;

			player.SetActive (true);
			playerWrong.SetActive (false);
			cam1.SetActive (true);
			cam2.SetActive (false);

			GSP.canIUseItDown = false;
			GSP.canIUseItMid = false;
			GSP.canIUseItUp = false;

			GSP.state1 = false;
			GSP.state2 = false;
			GSP.state3 = false;
			GSP.OutlineDown.SetActive (false);
			GSP.OutlineMid.SetActive (false);
			GSP.OutlineTop.SetActive (false);
		}
	}

	void OnTriggerEnter (Collider coll){
		if (coll.tag == "Player") {
			playerIsHere = true;
		}
	}
	void OnTriggerExit (Collider coll){
		if (coll.tag == "Player") {
			playerIsHere = false;
		}
	}
}
