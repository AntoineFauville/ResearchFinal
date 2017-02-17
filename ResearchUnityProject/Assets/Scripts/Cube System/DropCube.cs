using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ThirdPersonCamera;

public class DropCube : MonoBehaviour {
	/*
	public GameObject prefabCube;
	public GameObject prefabCubeArcheo;
	GameObject cubeOnAss;
	public GameObject artefactArcheo;

	public GameObject MainCamera;
	public GameObject Cam2;

	ZoneGestion ZG;

	GameObject ScanningPanel; 

	OpenCloseBook OCB;

	public Transform LaunchCube;

	public bool isCubeOnGround;
	// Use this for initialization
	void Start () {
		ScanningPanel = GameObject.Find ("Scanning");
		ScanningPanel.SetActive (false);
		OCB = GameObject.Find ("ScriptManager").GetComponent<OpenCloseBook> ();
		ZG = GameObject.Find ("ScriptManager").GetComponent<ZoneGestion> ();
		cubeOnAss = GameObject.Find ("ArtefactOnAss");
	}
	
	// Update is called once per frame
	void Update () {

		//il faut scan avant de savoir si on est dans la z
	/*	if (ZG.didICheckNextVillage == true) {

			//drop it depending if we are in or out
			if (ZG.AmIInsideArea) {
				// et que j'appuie sur le bouton pour le cube, je le lache, mais ca instantiate le cube avec le module d'archéologie
				if (Input.GetButtonDown ("dropcube") && !isCubeOnGround) {
					/*Instantiate (prefabCubeArcheo, LaunchCube.position, LaunchCube.rotation);
					isCubeOnGround = true;
					ScanningPanel.SetActive (true);*/
					//camera menu + artefact
				/*	ZG.scanning();
					artefactArcheo.SetActive (true);
					Cam2.SetActive(true);
					MainCamera.SetActive(false);
					isCubeOnGround = true;

				}
			} else {
				if (Input.GetButtonDown ("dropcube") && !isCubeOnGround /*&& OCB.isBookOpen == false) {
					// et que j'appuie sur le bouton pour le cube, je le lache, mais ca instantiate le cube avec le module de recherche
			/*		Instantiate (prefabCube, LaunchCube.position, LaunchCube.rotation);
					isCubeOnGround = true;
					ZG.scanning();
					ScanningPanel.SetActive (true);
					//StartCoroutine ("returnCubeBool");
				}
			}
		} else {
			// et que j'appuie sur le bouton pour le cube, je le lache, mais ca instantiate le cube avec le module de recherche
				if (Input.GetButtonDown ("dropcube") && !isCubeOnGround) {
					Instantiate (prefabCube, LaunchCube.position, LaunchCube.rotation);
					isCubeOnGround = true;
					ZG.scanning();
					ScanningPanel.SetActive (true);
				}
		}

		//pick it up
		if (isCubeOnGround) {
			cubeOnAss.SetActive (false);
		} else {
			cubeOnAss.SetActive (true);
		}

	}

	IEnumerator returnCubeBool () {
		yield return new WaitForSeconds (0.3f);
		ScanningPanel.SetActive (false);
		isCubeOnGround = false;
	}*/
}
