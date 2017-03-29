using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndRockEnigme : MonoBehaviour {

	public Transform doorRight1;
	public Transform doorLeft;
	public Vector3 finalleftDoorTransform;
	public Vector3 finalRightDoorTransform;

	//outlines
	public GameObject Outline1;
	public GameObject Outline2;
	public GameObject Outline3;

	//images
	public Image img1;
	public Image img2;
	public float fillAmoutImage = 0.05f;

	//distance calcul
	public GameObject rock1;
	public GameObject rock2;
	public GameObject rock3;

	public GameObject rockref1;
	public GameObject rockref2;
	public GameObject rockref3;

	public float dist1;
	public float dist2;
	public float dist3;

	public GestionSelectionRocks GSR;

	//globals
	public bool EnigmeDone = false;
	public bool OpenDoor = false;
	public bool launchingEnd = false;
	public bool AmIAtEndAnim = false;

	public float fillSec = 7.0f;
	public float openDoor = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		dist1 = Vector3.Distance (rock1.transform.position, rockref1.transform.position);
		dist2 = Vector3.Distance (rock2.transform.position, rockref2.transform.position);
		dist3 = Vector3.Distance (rock3.transform.position, rockref3.transform.position);

		if (dist1 <= 0.3f && dist2 <= 0.3f && dist3 <= 0.3f) {
			EnigmeDone = true;
		}

		if (EnigmeDone && !launchingEnd) {
			launchingEnd = true;
			GSR.gestionIsOn = false;
			GSR.state1 = false;
			GSR.state2 = false;
			GSR.state3 = false;

			rock1.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
			rock2.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
			rock3.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;

			StartCoroutine ("fillImagesBeforeOpenWalls");
		}

		//fill images
		if (EnigmeDone) {
			img1.fillAmount += fillAmoutImage;
			img2.fillAmount += fillAmoutImage;
		}

		if (img1.fillAmount > 1) {
			img1.fillAmount = 1;
		}
		if (img2.fillAmount > 1) {
			img2.fillAmount = 1;
		}

		if (OpenDoor) {
			doorLeft.transform.position += finalleftDoorTransform;
			doorRight1.transform.position += finalRightDoorTransform;
		}
	}

	IEnumerator fillImagesBeforeOpenWalls () {
		transform.GetComponent<GestionSelectionRocks> ().enabled = false;
		Outline1.SetActive (false);
		Outline2.SetActive (false);
		Outline3.SetActive (false);
		print ("everythingisdesactivated");
		yield return new WaitForSeconds (fillSec);
		OpenDoor = true;
		print ("OpenDoorTrue");
		yield return new WaitForSeconds (openDoor);
		OpenDoor = false;
		AmIAtEndAnim = true;
		print ("OpenDoorfalse");
	}
}
