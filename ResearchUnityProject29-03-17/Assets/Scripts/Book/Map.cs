using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPersonCamera;

public class Map : MonoBehaviour {

	GameObject MapGameObject;
	GameObject canvasMainCamera;

	GameObject BigArea;
	GameObject SmallArea;

	GameObject ImageMapSmall;
	GameObject ImageMapZoneSmall;
	GameObject ImageMapVillage;
	GameObject ImageMapZoneVillage;

	public GameObject PanelArtefact;
	public GameObject PanelBook;
	public GameObject PanelMap;

	ZoneGestion ZG;
	OpenCloseBook OCB;

	public bool mapOpen = false;

	// Use this for initialization
	void Start () {
		MapGameObject = GameObject.Find ("CameraMap");

		ImageMapSmall = GameObject.Find ("ImageMapSmall");
		ImageMapZoneSmall = GameObject.Find ("ImageMapZoneSmall");
		ImageMapVillage = GameObject.Find ("ImageMapVillage");
		ImageMapZoneVillage = GameObject.Find ("ImageMapZoneVillage");

		ImageMapSmall.SetActive(false);
		ImageMapZoneSmall.SetActive(false);
		ImageMapVillage.SetActive(false);
		ImageMapZoneVillage.SetActive(false);

		MapGameObject.SetActive (false);

		BigArea = GameObject.Find ("SphereVillage");
		SmallArea = GameObject.Find ("SphereSmall");

		SmallArea.SetActive(false);
		BigArea.SetActive(false);

		ZG = GameObject.Find ("ScriptManager").GetComponent<ZoneGestion> ();
		OCB = GameObject.Find ("ScriptManager").GetComponent<OpenCloseBook> ();
		canvasMainCamera = GameObject.Find ("Canvas Book Notification MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Map") && !mapOpen && OCB.ImInMenuBool == false) {
			OCB.ImInMenuBool = true;
			OCB.canvas.SetActive (true);
			OCB.mainCamera.SetActive (false);
			OCB.SecondCamera.SetActive (true);
			canvasMainCamera.SetActive (false);
			OCB.isBookOpen = true;
			mapOpen = true;
			MapGameObject.SetActive (true);

			PanelArtefact.SetActive (false);
			PanelBook.SetActive (false);
			PanelMap.SetActive (true);
		}
		else if ((Input.GetButtonDown ("Map") || Input.GetButtonDown ("Cancel")) && OCB.ImInMenuBool && mapOpen) {
			mapOpen = false;

			OCB.mainCamera.SetActive (true);
			OCB.SecondCamera.SetActive (false);
			canvasMainCamera.SetActive (true);
			OCB.canvas.SetActive (false);
			OCB.isBookOpen = false;

			MapGameObject.SetActive (false);

			PanelArtefact.SetActive (false);
			PanelBook.SetActive (false);
			PanelMap.SetActive (true);

			StartCoroutine("retourEchap");
		}
			
	/*	if (ZG.didICheckNextVillage == true) {

			if (ZG.didCubeGotIntoTownOnce == true) {
				ImageMapVillage.SetActive (true);
				ImageMapZoneVillage.SetActive (false);
			} else {
				BigArea.SetActive (true);
				ImageMapZoneVillage.SetActive (true);
			}
		}

		if (ZG.didICheckSmallThing == true) {

			if (ZG.didCubeGotInSmallOnce == true) {
				ImageMapSmall.SetActive (true);
				ImageMapZoneSmall.SetActive (false);
			} else {
				SmallArea.SetActive (true);
				ImageMapZoneSmall.SetActive (true);
			}
		}	*/
	}

	public void CloseMapButton () {
		mapOpen = false;
		MapGameObject.SetActive (false);
	}

	public void OpenMapButton () {
		OCB.ImInMenuBool = true;
		OCB.canvas.SetActive (true);
		OCB.mainCamera.SetActive (false);
		OCB.SecondCamera.SetActive (true);
		canvasMainCamera.SetActive (false);
		OCB.isBookOpen = true;
		mapOpen = true;
		MapGameObject.SetActive (true);
	}

	IEnumerator retourEchap () {
		yield return new WaitForSeconds (0.1f);
		OCB.ImInMenuBool = false;
	}
}
