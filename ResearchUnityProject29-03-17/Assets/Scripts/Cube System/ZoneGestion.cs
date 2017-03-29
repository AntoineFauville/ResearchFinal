using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneGestion : MonoBehaviour {
	/*
	//list searching in between actual transform of area and stuff

	public bool IsAllAboutFirstVillage;

	public GameObject Player;
	public GameObject MainCamera;

	GameObject canvasAnimWhite;
	bool activateCanvasUp;
	public GameObject RespawnEnigmeTotem;

	public GameObject BlocageCube;
	DeathSystem DS;	
	GameObject Artefact;


	public GameObject CylindreLight;
	//bool scan

	public bool didICheckNextVillage;
	public bool isThereSomthingAround;
	public bool didICheckSmallThing;

	public bool cubeIsHereInTown;
	public bool resoudreLEnigme;

	public bool cubeIsHereSmall;

	public bool didCubeGotIntoTownOnce;
	public bool didCubeGotInSmallOnce;

	GameObject ScanningFeedBack01;
	GameObject ScanningFeedBack02;
	GameObject ScanningFeedBack03;

	public GameObject[] ListDeZone;

	public GameObject[] SmallObject;

	public bool AmIInsideArea;

	public GameObject TextVertical;
	public GameObject TextDescription;
	public GameObject TextSmall;

	//animation

	public Animator animVillage;
	bool animBoolVillage;

	public Animator anim;
	bool animBool;

	public GameObject ImageBookVillage;
	public GameObject ImageBookSmall;

	public Animator UIScanning01;
	public Animator UIScanning02;
	public Animator UIScanning03;
	bool animUI;

	DropCube dc;
	SanityGestion SG;
	public GameObject artefactArcheo;

	// Use this for initialization
	void Start () {
		dc = GameObject.Find ("Player").GetComponent<DropCube>();
		SG = GameObject.Find ("Player").GetComponent<SanityGestion>();
		canvasAnimWhite = GameObject.Find ("CanvasWhiteAnim");
		//TextVertical = GameObject.Find ("Text petit vertical");
		//TextDescription = GameObject.Find ("Text full text description");
		//TextSmall = GameObject.Find ("Text small text description");
		//BlocageCube = GameObject.Find ("BlocageCube");
		DS = GameObject.Find ("Player").GetComponent<DeathSystem>();
		//Player = GameObject.Find ("Player");
		//MainCamera = GameObject.Find ("Main Camera Main");
		ScanningFeedBack01 = GameObject.Find ("PanelNewMapInfoScan");
		ScanningFeedBack02 = GameObject.Find ("PanelNewMapInfoScanned");
		ScanningFeedBack03 = GameObject.Find ("PanelNewMapInfoScannedSmall");
		//ImageBookVillage = GameObject.Find ("ButtonImageBouquinVillage01");
		//ImageBookSmall = GameObject.Find ("ButtonImageBouquinPots");
		ScanningFeedBack01.SetActive (true);
		ScanningFeedBack02.SetActive (false);
		ScanningFeedBack03.SetActive (false);
		//RespawnEnigmeTotem = GameObject.Find ("RespawnEnigmeTotem");
		ImageBookVillage.SetActive (false);
		ImageBookSmall.SetActive (false);


	}
	
	// Update is called once per frame
	void Update () {
		
			
		animVillage.SetBool ("AnimVillageBool", animBoolVillage);
		anim.SetBool ("ActivateDemoSmall",animBool);
		//distance face au village
		if(!IsAllAboutFirstVillage)
		{
			float distance = Vector3.Distance(Player.transform.position, ListDeZone[0].transform.position);
			//inside area

			if (!cubeIsHereInTown) {

				if (distance < 80) {
					//print ("IN");
					AmIInsideArea = true;
				}
				//outside area
				if (distance >= 80) {
					//print ("OUT"); 
					AmIInsideArea = false;
				}

			} else if (cubeIsHereInTown && !didCubeGotIntoTownOnce) {

				//launch animation du village
				StartCoroutine("waitAnimFirstVillage");
				//bloquer le cube, destroy + faire spawn le village
				//add 1 to list des endroits à visiter.$
				//une fois résolue -> resoudreLEnigme = true;
				didCubeGotIntoTownOnce = true;
				ImageBookVillage.SetActive (true);
				StartCoroutine ("returnBoolAnim");
				cubeIsHereInTown = false;
			}

		}

		if (activateCanvasUp) {
			canvasAnimWhite.GetComponent<CanvasGroup> ().alpha += 0.1f;
		}



		//distance face a un petit objet
		float distanceToSmallObject = Vector3.Distance(Player.transform.position, SmallObject[0].transform.position);

		if (!cubeIsHereSmall) {
			if (distanceToSmallObject < 20) {
				isThereSomthingAround = true;
			} else {
				isThereSomthingAround = false;
			}
		} else if (cubeIsHereSmall) {
			didCubeGotInSmallOnce = true;
			animBool = true;
			ImageBookSmall.SetActive (true);
			cubeIsHereSmall = false;
		}


		//scanning
		if (!didICheckNextVillage) {
			// si j'ai rien scanner 
			ScanningFeedBack01.SetActive (true);
			//UIScanning01.SetBool ("NewObjectiveActiv",animUI);
			ScanningFeedBack02.SetActive (false);
			ScanningFeedBack03.SetActive (false);
			TextVertical.GetComponent<Text> ().text = "0 0";
			TextSmall.GetComponent<Text> ().text = " ";
			TextDescription.GetComponent<Text> ().text = "Fermez le menu, ensuite appuyez sur E et utilisez le bouton 'scan' pour avoir un Objectif";

		} else {
			if(!didICheckSmallThing && isThereSomthingAround){
				ScanningFeedBack01.SetActive (false);
				ScanningFeedBack02.SetActive (false);
				ScanningFeedBack03.SetActive (true);
				//UIScanning03.SetBool ("NewObjectiveActiv",animUI);
				TextSmall.GetComponent<Text> ().text = "Nouveau petit Objet découvert en : A 1";
			} else if(!IsAllAboutFirstVillage) {
				TextVertical.GetComponent<Text> ().text = "C 1";
				TextDescription.GetComponent<Text> ().text = "Nouvelle entrée ! Le cube nous donne les coordonnées suivantes : C 1";
				ScanningFeedBack01.SetActive (false);
				ScanningFeedBack02.SetActive (true);
				//UIScanning02.SetBool ("NewObjectiveActiv",animUI);
				ScanningFeedBack03.SetActive (false);
			}
			//si je n'ai pas check le deuxieme village et que j'ai fini le deuxieme village
			//else if(IsAllAboutFirstVillage && didICheckNextVillage2){}
		}
	}

	public void scanning(){
		//new village found
		// 3 états différents

		// 1 new village found - osef si y a des petits trucs pas loin prio village
		// si j'appuie sur scan ca lance le scan
		if (!didICheckNextVillage) {
			//animUI = true;
			//StartCoroutine ("returnAnimBool");
			StartCoroutine ("timeOfAnimDetect");
		}

		// 2 new small thing on the map
		 
		if (isThereSomthingAround && didICheckNextVillage && !didICheckSmallThing) {
			//animUI = true;
			//StartCoroutine ("returnAnimBool");
			StartCoroutine ("timeOfAnimDetect02");
		}
	}

	IEnumerator timeOfAnimDetect () {
		yield return new WaitForSeconds (1.0f);
		didICheckNextVillage = true;

		//A LANCER ICI LORSQU4ON A D2TETCER le village on relance en mettant didICheckNextVillage en, faux.
	}

	IEnumerator timeOfAnimDetect02 () {
		yield return new WaitForSeconds (1.0f);
		didICheckSmallThing = true;

		//A LANCER ICI LORSQU4ON A D2TETCER le smalltruc on relance en mettant didICheckSmallThing en, faux.
	}
	IEnumerator returnAnimBool(){
		yield return new WaitForSeconds (0.2f);
		animUI = true;
	}


	IEnumerator returnBoolAnim () {
		yield return new WaitForSeconds (0.5f);
		animBoolVillage = false;
	}

	IEnumerator waitAnimFirstVillage(){
		activateCanvasUp = true;

		SG.sanity = 1;
		artefactArcheo.SetActive (false);
		dc.StartCoroutine ("returnCubeBool");

		yield return new WaitForSeconds (1.0f);
		animBoolVillage = true;
		activateCanvasUp = false;
		Player.SetActive(false);
		yield return new WaitForSeconds (0.5f);
		canvasAnimWhite.GetComponent<CanvasGroup> ().alpha = 0.0f;
		DS.EnigmeActiveeMortSystemOn = true;
		MainCamera.SetActive (false);
		BlocageCube.GetComponent<VillageDecouvertBlocageCube> ().villageAnimLaunched = true;
		/*Artefact = GameObject.Find ("ArtefactArcheo(Clone)");
		Artefact.SetActive (false);*/
	/*	yield return new WaitForSeconds (15.5f);
		//RespawnEnigmeTotem = GameObject.Find ("RespawnEnigmeTotem");
		Player.SetActive(true);
		CylindreLight.SetActive (false);
		Player.transform.position = RespawnEnigmeTotem.transform.position;
		//print ("hey");
		//Player.SetActive(true);
		MainCamera.SetActive (true);
	}*/
}
