using UnityEngine;
using System.Collections;

public class PlayerActivateRockEnigme : MonoBehaviour {

	public GameObject player;
	public GameObject playerCrounching;
	public GameObject cam1;
	public GameObject cam2;

	public GameObject rock1;
	public GameObject rock2;
	public GameObject rock3;

	//outlines
	public GameObject Outline1;
	public GameObject Outline2;
	public GameObject Outline3;


	public GameObject scriptGestion;

	public GestionSelectionRocks GSR;
	public EndRockEnigme ERE;

	public bool amIOnEnigmeRock = false;
	public bool isItPlayer = false;


	// Use this for initialization
	void Start () {
		cam2.SetActive (false);
		playerCrounching.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (ERE.EnigmeDone == false) {
			if (Input.GetButtonDown ("Submit") && !amIOnEnigmeRock && isItPlayer) {
				//activate a state
				GSR.state1 = true;
				GSR.gestionIsOn = true;
				amIOnEnigmeRock = true;

				player.SetActive (false);
				playerCrounching.SetActive (true);
				cam2.SetActive (true);
				cam1.SetActive (false);
			}
			else if (Input.GetButtonDown ("Submit") && amIOnEnigmeRock && isItPlayer) {
				//activate a state
				GSR.state1 = false;
				GSR.state2 = false;
				GSR.state3 = false;
				GSR.gestionIsOn = false;
				amIOnEnigmeRock = false;

				rock1.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
				rock2.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
				rock3.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;

				Outline1.SetActive (false);
				Outline2.SetActive (false);
				Outline3.SetActive (false);

				player.SetActive (true);
				playerCrounching.SetActive (false);
				cam2.SetActive (false);
				cam1.SetActive (true);
			}
		}
		if (ERE.EnigmeDone && ERE.AmIAtEndAnim) {
			if (Input.GetButtonDown ("Submit") && amIOnEnigmeRock && isItPlayer) {
				player.SetActive (true);
				playerCrounching.SetActive (false);
				cam2.SetActive (false);
				cam1.SetActive (true);
			}
		}
	}

	void OnTriggerEnter (Collider coll){
		if(coll.tag == "Player"){
			isItPlayer = true;
			print (isItPlayer);
		}
	}
	void OnTriggerExit (Collider coll){
		if(coll.tag == "Player"){
			isItPlayer = false;
		}
	}
}
