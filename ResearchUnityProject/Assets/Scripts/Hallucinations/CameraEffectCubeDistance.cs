using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MorePPEffects;
using UnityStandardAssets.ImageEffects;

public class CameraEffectCubeDistance : MonoBehaviour {


	SanityGestion SG;

	GameObject MainCam;

	public float localVariable;

	// Use this for initialization
	void Start () {
		MainCam = GameObject.Find ("Main Camera Main");
		SG = GameObject.Find ("Player").GetComponent<SanityGestion>();
	}
	
	// Update is called once per frame
	void Update () {
		localVariable = SG.sanity;


		if (localVariable > 0.9f) {
			MainCam.GetComponent<NormalMapDistortion> ().enabled = false;
			MainCam.GetComponent<NormalMapDistortion> ().speedY = 0.0f;
			MainCam.GetComponent<NormalMapDistortion> ().speedX = 0.0f;


			MainCam.GetComponent<Fisheye> ().strengthX = 0.03f;
			MainCam.GetComponent<Fisheye> ().strengthY = 0.03f;

			MainCam.GetComponent<Bloom> ().bloomIntensity = 0.1f;

			MainCam.GetComponent<Headache> ().speed = 0.0f;
			MainCam.GetComponent<Headache> ().strength = 0.0f;
		}

		else if(localVariable < 0.8f && localVariable > 0.6f){
			MainCam.GetComponent<NormalMapDistortion> ().enabled = true;
			MainCam.GetComponent<NormalMapDistortion> ().speedY = 0.3f;
			MainCam.GetComponent<NormalMapDistortion> ().speedX = 0.3f;

			MainCam.GetComponent<Fisheye> ().strengthX = 0.06f;
			MainCam.GetComponent<Fisheye> ().strengthY = 0.06f;

			MainCam.GetComponent<Bloom> ().bloomIntensity = 0.3f;

			MainCam.GetComponent<Headache> ().speed = 0.5f;
			MainCam.GetComponent<Headache> ().strength = 1f;
		}

		else if(localVariable < 0.6f && localVariable > 0.4f){
			MainCam.GetComponent<NormalMapDistortion> ().enabled = true;
			MainCam.GetComponent<NormalMapDistortion> ().speedY = 0.6f;
			MainCam.GetComponent<NormalMapDistortion> ().speedX = 0.6f;

			MainCam.GetComponent<Fisheye> ().strengthX = 0.1f;
			MainCam.GetComponent<Fisheye> ().strengthY = 0.1f;

			MainCam.GetComponent<Bloom> ().bloomIntensity = 0.75f;

			MainCam.GetComponent<Headache> ().speed = 1f;
			MainCam.GetComponent<Headache> ().strength = 3f;
		}
		else if(localVariable < 0.4f && localVariable > 0.2f){
			MainCam.GetComponent<NormalMapDistortion> ().enabled = true;
			MainCam.GetComponent<NormalMapDistortion> ().speedY = 1.2f;
			MainCam.GetComponent<NormalMapDistortion> ().speedX = 1.2f;

			MainCam.GetComponent<Fisheye> ().strengthX = 0.25f;
			MainCam.GetComponent<Fisheye> ().strengthY = 0.25f;

			MainCam.GetComponent<Bloom> ().bloomIntensity = 1.0f;

			MainCam.GetComponent<Headache> ().speed = 1f;
			MainCam.GetComponent<Headache> ().strength = 6f;
		}


	}
}
