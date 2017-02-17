using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuDemo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void QuitGame(){
		StartCoroutine ("EndGame");
		Application.CancelQuit ();
	}

	public void launchDemoTechi(){
		StartCoroutine ("launchDemoTech");
	}

	public void launchDemoGraphi(){
		StartCoroutine ("launchDemoGraph");
	}

	public void launchMenuDemo(){
		StartCoroutine ("launchMenu");
	}

	IEnumerator launchDemoTech (){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("Technical Scene");
	}

	IEnumerator launchDemoGraph (){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("AAAAAAAAAAAAAAAAAA");
	}
		
	IEnumerator EndGame (){
		yield return new WaitForSeconds (0.2f);
		Application.CancelQuit ();
	}

	IEnumerator launchMenu (){
		yield return new WaitForSeconds (0.3f);
		SceneManager.LoadScene ("MenuScene");
	}
}
