using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using ThirdPersonCamera;

public class DebugDemo : MonoBehaviour {

	GameObject BlocageCube;

	DeathSystem DS;

	GameObject MenuCanvas;
	bool menuOpen;
	bool ImInMenuBool;

	OpenCloseBook OCB;

	// Use this for initialization
	void Start () {
		MenuCanvas = GameObject.Find ("CanvasMenu");
		BlocageCube = GameObject.Find ("BlocageCube");
		DS = GameObject.Find ("Player").GetComponent<DeathSystem>();
		MenuCanvas.SetActive (false);
		//OCB = GameObject.Find ("ScriptManager").GetComponent<OpenCloseBook> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Cancel") && !menuOpen && 
			ImInMenuBool == false
		) {
			ImInMenuBool = true;
			MenuCanvas.SetActive (true);
			menuOpen = true;
		} else if (Input.GetButtonDown ("Cancel") && menuOpen && 
			ImInMenuBool == true
		) {
			ImInMenuBool = false;
			MenuCanvas.SetActive (false);
			menuOpen = false;
		}

		//scene loading

		if (Input.GetKeyDown ("1")) {
			print ("1 pressed");
			Application.LoadLevel ("MenuScene");
		} else if (Input.GetKeyDown ("2")) {
			print ("2 pressed");
			Application.LoadLevel ("Technical Scene");
		} else if (Input.GetKeyDown ("3")) {
			print ("3 pressed");
			Application.LoadLevel ("AAAAAAAAAAAAAAAAAA");

		//

		} else if (Input.GetKeyDown ("4")) {
			print ("4 pressed");
			//BlocageCube.GetComponent<VillageDecouvertBlocageCube> ().villageAnimLaunched = true;
			DS.EnigmeActiveeMortSystemOn = true;
		} else if (Input.GetKeyDown ("5")) {
			print ("5 pressed");

		} 
	}

	public void MenuEchap(){
		OCB.ImInMenuBool = true;
		MenuCanvas.SetActive (true);
		menuOpen = true;
	}

	public void MenuEchapClose(){
		OCB.ImInMenuBool = false;
		MenuCanvas.SetActive (false);
		menuOpen = false;
	}
}
