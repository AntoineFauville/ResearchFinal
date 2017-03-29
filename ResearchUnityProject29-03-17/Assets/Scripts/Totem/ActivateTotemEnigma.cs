using UnityEngine;
using System.Collections;
using ThirdPersonCamera;

public class ActivateTotemEnigma : MonoBehaviour {

	public bool playerIsHere = false;
	public bool amIOn = false;

	GameObject player;
	//GameObject playerWrong;
	GameObject cam1;
	GameObject cam2;

	GameObject MapAndInventory;

	public GameObject cube;

	bool GetInGetOut;

	public EndTotemEnigma EndingTotemScript;
	public GestionSelectionParts GSP;

	void Start () {
		player = GameObject.Find ("Player");
	//	playerWrong = GameObject.Find ("CrounchingPlayerPuzzleTotem");
		cam1 = GameObject.Find ("Main Camera Main");
		cam2 = GameObject.Find ("CameraEnigmeTotem");
		//jouer et camera
//		playerWrong.SetActive (false);
		cam2.SetActive (false);
	}

	void Update () {

		if(EndingTotemScript.EnigmaIsDone == false && Input.GetButtonDown ("Submit") && playerIsHere && !GetInGetOut){
		//suis je ne suis pas la plateformetrigger et j'appuie sur submit et est ce que l'énigme est finie ?
			if (!amIOn) {
				amIOn = true;
				GetInGetOut = true;
				StartCoroutine ("waitInBetweenGetInGetOut");
			//joueur
				player.SetActive (false);
			//	playerWrong.SetActive (true);
				cam1.SetActive (false);
				cam2.SetActive (true);

			//GestionSelectionParts

				GSP.state1 = true;
				GSP.state2 = false;
				GSP.state3 = false;

				GSP.OutlineDown.SetActive (true);
				GSP.OutlineMid.SetActive (false);
				GSP.OutlineTop.SetActive (false);

			//suis je suis sur la plateformetrigger et j'appuie sur submit et est ce que l'énigme est finie ?
			} else if (amIOn) {
				amIOn = false;
				GetInGetOut = true;
				StartCoroutine ("waitInBetweenGetInGetOut");

				player.SetActive (true);
			//	playerWrong.SetActive (false);
				cam1.SetActive (true);
				cam2.SetActive (false);

			//GestionSelectionParts

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

	IEnumerator waitInBetweenGetInGetOut(){
		yield return new WaitForSeconds (0.5f);
		GetInGetOut = false;
	}
}
