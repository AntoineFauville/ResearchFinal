using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPersonCamera;

public class OpenCloseBook : MonoBehaviour {

	public GameObject canvas;
	public bool isBookOpen;
	public GameObject buttonOuvrirBook;

		GameObject canvasMainCamera;

		public GameObject PanelArtefact;
		public GameObject PanelBook;
		public GameObject PanelMap;

		public GameObject mainCamera;
		public GameObject SecondCamera;

		public GameObject MapGameObject;

		DropCube DC;
		public Map M;

		public bool ImInMenuBool = false;

	public FreeForm FF;

	public GameObject player;

	// Use this for initialization
	void Start () {
		canvas.SetActive (false);
			canvasMainCamera = GameObject.Find ("Canvas Book Notification MainCamera");
			mainCamera = GameObject.Find ("Main Camera Main");
			SecondCamera = GameObject.Find ("MenuCamera");
			mainCamera.SetActive (true);
			SecondCamera.SetActive (false);

			DC = GameObject.Find ("Player").GetComponent<DropCube> ();

			//MapGameObject = GameObject.Find ("CameraMap");
	}
	
	// Update is called once per frame
	void Update () {
			if (Input.GetButtonDown ("OpenBook") && !isBookOpen && !ImInMenuBool) {
			canvas.SetActive (true);
			mainCamera.SetActive (false);
			SecondCamera.SetActive (true);
			canvasMainCamera.SetActive (false);
			ImInMenuBool = true;
			//buttonOuvrirBook.SetActive (false);
			isBookOpen = true;

				M.mapOpen = false;
				MapGameObject.SetActive (false);

				PanelArtefact.SetActive (true);
				PanelBook.SetActive (false);
				PanelMap.SetActive (false);

		//	player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().enabled = false;
		//	player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = false;
		//	player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().v = 0;
		//	player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().h = 0;

				//FF.lockMouseCursor = false;
		} else 
				if ((Input.GetButtonDown ("OpenBook") || (Input.GetButtonDown ("Cancel") && ImInMenuBool )) && isBookOpen) {
				buttonOuvrirBook.SetActive (true);
				StartCoroutine("retourEchap");
				mainCamera.SetActive (true);
				SecondCamera.SetActive (false);
				canvasMainCamera.SetActive (true);
				canvas.SetActive (false);
				isBookOpen = false;

					M.mapOpen = false;
					MapGameObject.SetActive (false);
			
					PanelArtefact.SetActive (true);
					PanelBook.SetActive (false);
					PanelMap.SetActive (false);




		//		player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter> ().enabled = true;
		//		player.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl> ().enabled = true;

				//FF.lockMouseCursor = true;
		}
	}

		public void CloseInventory () {
			isBookOpen = false;
		}

		public void OpenInventory () {
		canvas.SetActive (true);
		mainCamera.SetActive (false);
		SecondCamera.SetActive (true);
		canvasMainCamera.SetActive (false);
		ImInMenuBool = true;
		//buttonOuvrirBook.SetActive (false);
		isBookOpen = true;

		M.mapOpen = false;
		MapGameObject.SetActive (false);

		PanelArtefact.SetActive (true);
		PanelBook.SetActive (false);
		PanelMap.SetActive (false);
		}

		IEnumerator retourEchap () {
			yield return new WaitForSeconds (0.1f);
			ImInMenuBool = false;
		}
	}

