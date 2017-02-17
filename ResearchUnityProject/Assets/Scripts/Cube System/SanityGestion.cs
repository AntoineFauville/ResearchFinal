using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityGestion : MonoBehaviour {

	public float sanity = 1;

	//graphic bar
	Image Sanity;

	// Use this for initialization
	void Start () {
		sanity = 1;
		Sanity = GameObject.Find ("Sanity").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

		Sanity.fillAmount = sanity;

		if (sanity < 0)
		{
			sanity = 0;
		}
	}
}
