using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Town1Receiver : MonoBehaviour {

	GameObject MainCamera;
	GameObject Player;

	GameObject ScriptTotem;

	Transform RespawnEnigmeTotem;

	VillageDecouvertBlocageCube VBBC;
	DetectableLocalManager DLM;
	SanityGestion SG;
	DeathSystem DS;

	EndTotemEnigma ETE;

	//animation 
	bool didILauchedAnim;
	//public Animator animVillage;
	bool animBoolVillage;

	GameObject artecfactNew;

	// Use this for initialization
	void Start () {
		VBBC = GameObject.Find ("BlocageCube").GetComponent<VillageDecouvertBlocageCube> ();
		DLM = GameObject.Find ("Town1").GetComponent<DetectableLocalManager> ();
		SG = GameObject.Find ("Player").GetComponent<SanityGestion>();
		DS = GameObject.Find ("Player").GetComponent<DeathSystem>();

		MainCamera = GameObject.Find ("Main Camera Main");
		Player = GameObject.Find ("Player");

		RespawnEnigmeTotem = GameObject.Find ("RespawnEnigmeTotem").transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		//animVillage.SetBool ("AnimVillageBool", animBoolVillage);

		if (DLM.isPlayerHere && Input.GetButtonDown ("Submit") && !didILauchedAnim) {
		//	print ("hey");
		//	didILauchedAnim = true;
			StartCoroutine("AnimDeDebutTotem");
		}
	}

	IEnumerator AnimDeDebutTotem (){
		//print ("heyyyy");
		//activateCanvasUp = true;  lanche l'image blanche au debut de l'animation
		//SG.sanity = 1;
	//	artecfactNew = GameObject.Find ("ARtefactOverLayInteraction");
	//	artecfactNew.SetActive (false);

		//yield return new WaitForSeconds (1.0f);
		//animBoolVillage = true;
		//activateCanvasUp = false;
		yield return new WaitForSeconds (0.5f);
		//Player.SetActive(false);
		//canvasAnimWhite.GetComponent<CanvasGroup> ().alpha = 0.0f;
		DS.EnigmeActiveeMortSystemOn = true;
		//MainCamera.SetActive (false);
		VBBC.VillageEstDeployer = true;
//		Artefact = GameObject.Find ("ArtefactArcheo(Clone)");
//		Artefact.SetActive (false);
		//yield return new WaitForSeconds (15.5f);
		//RespawnEnigmeTotem = GameObject.Find ("RespawnEnigmeTotem");
		//Player.SetActive(true);
		//CylindreLight.SetActive (false);
		//Player.transform.position = RespawnEnigmeTotem.transform.position;
		//print ("hey");
		//Player.SetActive(true);
		//MainCamera.SetActive (true);
	}
}
