using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityGestion : MonoBehaviour {

	public float sanity = 1;

	bool go = false;
	bool wait;

	//graphic bar
	Image Sanity;

	// Use this for initialization
	void Start () {
		sanity = 1;
		StartCoroutine ("waitToStartReferences");
	}


	IEnumerator waitToStartReferences(){
		yield return new WaitForSeconds (7.0f);
		//print ("hey");
		go = true;
		Sanity = GameObject.Find ("Sanity").GetComponent<Image> ();
	}

	void Update (){
		if(go && !wait){
			if (GameObject.Find ("Player").activeSelf == true) { 
				Sanity.fillAmount = sanity;
			}
			if (sanity < 0)
			{
				sanity = 0;
			}
			wait = true;
			StartCoroutine ("waithalfsec");
		}
	}

	IEnumerator waithalfsec(){
		yield return new WaitForSeconds (0.05f);
		wait = false;
	}
}
