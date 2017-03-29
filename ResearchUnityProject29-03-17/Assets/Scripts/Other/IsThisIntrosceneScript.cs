using UnityEngine;
using System.Collections;

public class IsThisIntrosceneScript : MonoBehaviour {

	public bool isThisIntroScene;

	public float amountOfSecOfIntroScene;

	public GameObject player;
	public GameObject wrongPlayer;
	public GameObject playercam;

	public bool didISkip;
	public Animator animIntro;
	public bool animBool;

	public GameObject animationIntroObject;
	// Use this for initialization
	void Start () {
		if (isThisIntroScene) {
			wrongPlayer.SetActive (true);
			player.SetActive (false);
			playercam.SetActive (false);
			animationIntroObject.SetActive (true);
			StartCoroutine ("returnIntroPlayable");
			isThisIntroScene = false;
		}
	}

	void Update () {
		if(Input.GetButtonDown("Submit") && !didISkip){
			didISkip = true;
			animIntro.SetBool ("pressStart",animBool);
			animBool = true;
			StartCoroutine ("SkipIntro");
		}
	}

	IEnumerator returnIntroPlayable () {
		yield return new WaitForSeconds (amountOfSecOfIntroScene);
		player.SetActive (true);
		playercam.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		wrongPlayer.SetActive (false);
		animationIntroObject.SetActive (false);
	}

	IEnumerator SkipIntro () {
		player.SetActive (true);
		playercam.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		wrongPlayer.SetActive (false);
		animationIntroObject.SetActive (false);
	}
}
