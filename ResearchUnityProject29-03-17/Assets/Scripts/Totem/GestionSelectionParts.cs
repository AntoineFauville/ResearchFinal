using UnityEngine;
using System.Collections;

public class GestionSelectionParts : MonoBehaviour {

	public bool state1;
	public bool state2;
	public bool state3;

	public GameObject OutlineDown;
	public GameObject OutlineMid;
	public GameObject OutlineTop;

	public bool canIUseItDown;
	public bool canIUseItMid;
	public bool canIUseItUp;

	public RotationEnigmeLazer RotationDown;
	public RotationEnigmeLazer RotationMid;
	public AnimTopPartNotMoving RotationUp;

	bool returnAxisBool = false;

	// Use this for initialization
	void Start () {
		state1 = false;
		state2 = false;
		state3 = false;
		OutlineDown.SetActive(false);
		OutlineMid.SetActive (false);
		OutlineTop.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

		RotationDown.canIUseIt = canIUseItDown; 
		RotationMid.canIUseIt = canIUseItMid;
		RotationUp.canIUseIt = canIUseItUp;

		//establishing the states
		if (state1) {
				canIUseItDown = true;
				canIUseItMid = false;
				canIUseItUp = false;

			OutlineDown.SetActive (true);
			OutlineMid.SetActive (false);
			OutlineTop.SetActive (false);
		}
		else if (state2) {
				canIUseItDown = false;
				canIUseItMid = true;
				canIUseItUp = false;

			OutlineDown.SetActive (false);
			OutlineMid.SetActive (true);
			OutlineTop.SetActive (false);
		}
		else if (state3) {
				canIUseItDown = false;
				canIUseItMid = false;
				canIUseItUp = true;

			OutlineDown.SetActive (false);
			OutlineMid.SetActive (false);
			OutlineTop.SetActive (true);
		}

		//switching from one to other
		if (state1 && Input.GetAxis ("Vertical") >= 0.4f && !returnAxisBool) {
			state1 = false;
			state2 = true;
			returnAxisBool = true;
			StartCoroutine ("returnAxis");
		} else if (state2 && Input.GetAxis ("Vertical") >= 0.4f && !returnAxisBool) {
			state2 = false;
			state3 = true;
			returnAxisBool = true;
			StartCoroutine ("returnAxis");
		}
		if (state3 && Input.GetAxis ("Vertical") <= -0.4f && !returnAxisBool) {
			state3 = false;
			state2 = true;
			returnAxisBool = true;
			StartCoroutine ("returnAxis");
		} else if (state2 && Input.GetAxis ("Vertical") <= -0.4f && !returnAxisBool) {
			state2 = false;
			state1 = true;
			returnAxisBool = true;
			StartCoroutine ("returnAxis");
		}
	}

	IEnumerator returnAxis(){
		yield return new WaitForSeconds (0.5f);
		returnAxisBool = false;
	}
}
