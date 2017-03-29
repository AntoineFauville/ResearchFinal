using UnityEngine;
using System.Collections;

public class GestionSelectionRocks : MonoBehaviour {

	public GameObject cubeOutline1;
	public GameObject cubeOutline2;
	public GameObject cubeOutline3;

	public GameObject rock1;
	public GameObject rock2;
	public GameObject rock3;

	public bool state1; // small rock
	public bool state2; // middle rock
	public bool state3; // big rock

	public bool gestionIsOn = false;
	public bool CanIUseVerticalAgain;

	// Use this for initialization
	void Start () {
		cubeOutline1.SetActive (false);
		cubeOutline2.SetActive (false);
		cubeOutline3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (gestionIsOn) {
			if (state1 == true) {
				rock1.gameObject.GetComponent<NavMeshMovingRock> ().enabled = true;
				rock2.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
				rock3.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;

				cubeOutline1.SetActive (true);
				cubeOutline2.SetActive (false);
				cubeOutline3.SetActive (false);
			}
			if (state2 == true) {
				rock1.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
				rock2.gameObject.GetComponent<NavMeshMovingRock> ().enabled = true;
				rock3.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;

				cubeOutline1.SetActive (false);
				cubeOutline2.SetActive (true);
				cubeOutline3.SetActive (false);
			}
			if (state3 == true) {
				rock1.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
				rock2.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
				rock3.gameObject.GetComponent<NavMeshMovingRock> ().enabled = true;

				cubeOutline1.SetActive (false);
				cubeOutline2.SetActive (false);
				cubeOutline3.SetActive (true);
			}
		}else if (!gestionIsOn) {
			rock1.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
			rock2.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
			rock3.gameObject.GetComponent<NavMeshMovingRock> ().enabled= false;
		}


		if(state1 == true && Input.GetAxis("Vertical") > 0.8 && CanIUseVerticalAgain == false)
		{
			state1 = false;
			state2 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
		else if(state2 == true && Input.GetAxis("Vertical") > 0.8 && CanIUseVerticalAgain == false)
		{
			state2 = false;
			state3 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
		if(state2 == true && Input.GetAxis("Vertical") < -0.8 && CanIUseVerticalAgain == false)
		{
			state2 = false;
			state1 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
		else if(state3 == true && Input.GetAxis("Vertical") < -0.8 && CanIUseVerticalAgain == false)
		{
			state3 = false;
			state2 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
	}

	IEnumerator waitForVerticalInput () {
		yield return new WaitForSeconds (0.3f);
		CanIUseVerticalAgain = false;
	}
}
