using UnityEngine;
using System.Collections;

public class ActivateCirclePuzzle : MonoBehaviour {

	public GameObject player;
	public GameObject playerCrounching;
	public GameObject cam1;
	public GameObject cam2;

	public GameObject scriptDoor;
	public GameObject outline1;
	public GameObject outline2;
	public GameObject outline3;

	public GameObject circle1GestionScript;
	public GameObject circle2GestionScript;
	public GameObject circle3GestionScript;
	public GameObject circleGeneralGestion;

	public CircleOpeningAfterEndRotation COAER;

	public bool amIOn = false;

	public bool isPlayerHere = false;

	// Use this for initialization
	void Start () {
		cam2.SetActive (false);
		playerCrounching.SetActive (false);

		scriptDoor.SetActive (false);
		outline1.SetActive (false);
		outline2.SetActive (false);
		outline3.SetActive (false);
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			isPlayerHere = true;
		}
	}

	void OnTriggerExit (Collider coll) {
		if (coll.tag == "Player") {
			isPlayerHere = false;
		}
	}

	void Update () {

		if (COAER.haveIPlayedOnce) 
		{
			circle1GestionScript.SetActive (false);
			circle2GestionScript.SetActive (false);
			circle3GestionScript.SetActive (false);
			circleGeneralGestion.SetActive (false);
			outline1.SetActive (false);
			outline2.SetActive (false);
			outline3.SetActive (false);
		}
		if (COAER.haveIPlayedOnce == false) {
			if (Input.GetButtonDown ("Submit") && amIOn == false && isPlayerHere == true) {
				player.SetActive (false);
				playerCrounching.SetActive (true);
				cam2.SetActive (true);
				cam1.SetActive (false);

				amIOn = true;
				scriptDoor.SetActive (true);
				outline1.SetActive (true);
				outline2.SetActive (true);
				outline3.SetActive (true);
			} else if (Input.GetButtonDown ("Submit") && amIOn == true && isPlayerHere == true) {
				player.SetActive (true);
				playerCrounching.SetActive (false);
				cam2.SetActive (false);
				cam1.SetActive (true);

				amIOn = false;
				scriptDoor.SetActive (false);
				outline1.SetActive (false);
				outline2.SetActive (false);
				outline3.SetActive (false);
			}
		}
		if (COAER.haveIPlayedOnce == true && COAER.canImoveAfterAnimationOfDoorOpening == true) {
			if (Input.GetButtonDown ("Submit") && amIOn == true && isPlayerHere == true) {
				player.SetActive (true);
				playerCrounching.SetActive (false);
				cam2.SetActive (false);
				cam1.SetActive (true);

				amIOn = false;
			}
		}
	}
}
