using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityGestion : MonoBehaviour {

	public float sanity = 1;

	bool go = false;

	//graphic bar
	Image Sanity;

	// Use this for initialization
	void Start () {
		sanity = 1;
		StartCoroutine ("waitToStartReferences");
	}


	IEnumerator waitToStartReferences(){
		yield return new WaitForSeconds (7.0f);
		print ("hey");
		Sanity = GameObject.Find ("Sanity").GetComponent<Image>();
		go = true;
	}

	void Update (){
		if(go){
			Sanity.fillAmount = sanity;
			Sanity = GameObject.Find ("Sanity").GetComponent<Image>();
			if (sanity < 0)
			{
				sanity = 0;
			}
		}
	}
}
