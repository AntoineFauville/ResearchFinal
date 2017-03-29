using UnityEngine;
using System.Collections;

public class ActivateAnimOnButtonPressed : MonoBehaviour {

	public bool didAnimLauched = false;

	public GameObject camPlayer;
	public GameObject Player;

	public GameObject ReplacementPayer;

	public GameObject AnimObject;

	public Animator anim;
	public float secondOfAnim = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Activate",didAnimLauched);

		if(Input.GetButtonDown("Submit") && didAnimLauched == false){
			didAnimLauched = true;
			camPlayer.SetActive (false);
			Player.SetActive (false);
			ReplacementPayer.SetActive (true);

			StartCoroutine ("endOfAnimReturnPlayer");
		}
	}
		
	IEnumerator endOfAnimReturnPlayer () {
		yield return new WaitForSeconds (secondOfAnim);

		camPlayer.SetActive (true);
		Player.SetActive (true);
		ReplacementPayer.SetActive (false);
	}
}
