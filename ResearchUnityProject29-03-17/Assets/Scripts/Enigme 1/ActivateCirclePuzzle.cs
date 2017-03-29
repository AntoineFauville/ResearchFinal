using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class ActivateCirclePuzzle : MonoBehaviour {

	public GameObject player;
	//public GameObject playerCrounching;
	//public GameObject cam1;
	public GameObject cam2;

	GameObject MainCamera,
	MainCameraUI;

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

	GameManager GM;

	// Use this for initialization
	void Start () {
		cam2.GetComponent<Camera> ().enabled = false;
		//playerCrounching.SetActive (false);

		MainCamera = GameObject.Find ("Main Camera Main");
		MainCameraUI = GameObject.Find ("Main Camera Main UI");

		outline1.SetActive (false);
		outline2.SetActive (false);
		outline3.SetActive (false);

		GM = GameObject.Find ("ScriptManager").GetComponent<GameManager>();
		StartCoroutine ("waitIntro");
	}

	IEnumerator waitIntro() {
		yield return new WaitForSeconds (0.5f);
		scriptDoor.SetActive (false);
		yield return new WaitForSeconds (7.0f);
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
				MainCamera.GetComponent<Camera> ().enabled = false;
				MainCameraUI.GetComponent<Camera> ().enabled = false;
				GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = false;
				player.GetComponent<FirstPersonController> ().enabled = false;
				//playerCrounching.SetActive (true);
				cam2.GetComponent<Camera> ().enabled = true;
				//cam1.SetActive (false);

				amIOn = true;
				scriptDoor.SetActive (true);
				outline1.SetActive (true);
				outline2.SetActive (true);
				outline3.SetActive (true);
			} else if (Input.GetButtonDown ("Submit") && amIOn == true && isPlayerHere == true) {
				MainCamera.GetComponent<Camera> ().enabled = true;
				MainCameraUI.GetComponent<Camera> ().enabled = true;
				GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = true;
				player.GetComponent<FirstPersonController> ().enabled = true;
				//playerCrounching.SetActive (false);
				cam2.GetComponent<Camera> ().enabled = false;
				//cam1.SetActive (true);

				amIOn = false;
				scriptDoor.SetActive (false);
				outline1.SetActive (false);
				outline2.SetActive (false);
				outline3.SetActive (false);
			}
		}
		if (COAER.haveIPlayedOnce == true && COAER.canImoveAfterAnimationOfDoorOpening == true) {
			if (Input.GetButtonDown ("Submit") && amIOn == true && isPlayerHere == true) {
				MainCamera.GetComponent<Camera> ().enabled = false;
				MainCameraUI.GetComponent<Camera> ().enabled = false;
				GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = false;
				player.GetComponent<FirstPersonController> ().enabled = false;
				//playerCrounching.SetActive (false);
				cam2.GetComponent<Camera> ().enabled = false;
				//cam1.SetActive (true);
				GM.DesactiverActionDisponibleLacherCube();
				amIOn = false;
			}
		}
	}
}
