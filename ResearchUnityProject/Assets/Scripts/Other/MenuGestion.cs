using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGestion : MonoBehaviour {

	public bool amILaunched = false;
	public CanvasGroup imageblanche;

	public GameObject ImageChargement;

	public bool state1, state2, state3;

	public GameObject state1Outline;
	public GameObject state2Outline;
	public GameObject state3Outline;

	public float amoutOfAlpha;

	private float amoutofsecInput = 0.6f;
	private bool canIInputAgain;

	private bool didIPess = false;
	// Use this for initialization
	void Start () {
		ImageChargement.SetActive (false);
		state1 = true;
		state2 = false;
		state3 = false;
		imageblanche.alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (amILaunched) {
			imageblanche.alpha += amoutOfAlpha;
		}

		if(Input.GetAxis("Vertical") <= -0.4f && !canIInputAgain && state1 == true){
			state1 = false;
			state2 = true;
			state3 = false;
			canIInputAgain = true;
			StartCoroutine ("returnInput");
		}
		if(Input.GetAxis("Vertical") <= -0.4f && !canIInputAgain && state2 == true){
			state1 = false;
			state2 = false;
			state3 = true;
			canIInputAgain = true;
			StartCoroutine ("returnInput");
		}
		if(Input.GetAxis("Vertical") >= 0.4f && !canIInputAgain && state2 == true){
			state1 = true;
			state2 = false;
			state3 = false;
			canIInputAgain = true;
			StartCoroutine ("returnInput");
		}
		if(Input.GetAxis("Vertical") >= 0.4f && !canIInputAgain && state3 == true){
			state1 = false;
			state2 = true;
			state3 = false;
			canIInputAgain = true;
			StartCoroutine ("returnInput");
		}

		if (state1){
			state1Outline.SetActive (true);
			state2Outline.SetActive (false);
			state3Outline.SetActive (false);

			if(Input.GetButtonDown("Submit") && !didIPess){
				didIPess = true;
				LoadScene ();
			}
		}

		if (state2){
			state1Outline.SetActive (false);
			state2Outline.SetActive (true);
			state3Outline.SetActive (false);

			if(Input.GetButtonDown("Submit") && !didIPess){
				didIPess = true;
				ContinueGame ();
				print("hey wait for it to be implemented");
			}
		}

		if (state3){
			state1Outline.SetActive (false);
			state2Outline.SetActive (false);
			state3Outline.SetActive (true);

			if(Input.GetButtonDown("Submit") && !didIPess){
				didIPess = true;
				QuitGame ();
			}
		}

	}

	public void ContinueGame(){
		print("hey wait for it to be implemented");
	}

	public void QuitGame(){
		amILaunched = true;
		StartCoroutine ("EndGame");
		Application.CancelQuit ();
	}

	public void LoadScene(){
		amILaunched = true;
		StartCoroutine ("launchGame");
	}

	IEnumerator launchGame (){
		amILaunched = true;
		yield return new WaitForSeconds (2.0f);
		ImageChargement.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene ("SceneIntroRemasterd");
	}

	IEnumerator EndGame (){
		amILaunched = true;
		yield return new WaitForSeconds (2.0f);
/*		if (runInEditMode) {
			amILaunched = false;
			imageblanche.alpha = 0.0f;
		}*/
		Application.CancelQuit ();
	}

	IEnumerator returnInput (){
		yield return new WaitForSeconds (amoutofsecInput);
		canIInputAgain = false;
	}
}
