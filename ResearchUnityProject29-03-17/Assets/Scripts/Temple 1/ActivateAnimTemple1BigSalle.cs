using UnityEngine;
using System.Collections;

public class ActivateAnimTemple1BigSalle : MonoBehaviour {

	public GameObject player;
	public GameObject wrongPlayerAnimTemple1;
	public GameObject cam1;
	public GameObject cam2;
	public GameObject cam3;
	public GameObject cam4;

	public Animator anim;

	public bool DidIAllreadyPlayedAnim = false;

	public float secOfAnim;

	public bool activateAnim = false;

	public bool playerIsHere = false;

	// Use this for initialization
	void Start () {
		cam2.SetActive(false);
		wrongPlayerAnimTemple1.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		anim.SetBool ("ActivateAnimTemple1",activateAnim);

		if (Input.GetButtonDown ("Submit") && playerIsHere && !DidIAllreadyPlayedAnim) {
			cam2.SetActive(true);
			wrongPlayerAnimTemple1.SetActive(true);
			player.SetActive (false);
			activateAnim = true;
			StartCoroutine ("returnToPlayer");
			DidIAllreadyPlayedAnim = true;
		}
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.tag == "Player") {
			playerIsHere = true;
		}
	}

	void OnTriggerExit(Collider coll) {
		if (coll.tag == "Player") {
			playerIsHere = false;
		}
	}

	IEnumerator returnToPlayer (){
		yield return new WaitForSeconds (0.5f);
		cam1.SetActive (true);
		yield return new WaitForSeconds (secOfAnim);
		cam2.SetActive (false);
		cam3.SetActive (false);
		cam4.SetActive (false);
		wrongPlayerAnimTemple1.SetActive (false);
		player.SetActive (true);
	}
}
