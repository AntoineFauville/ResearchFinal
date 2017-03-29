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
		SG = GameObject.Find ("ScriptManager").GetComponent<SanityGestion>();
	}
	
	// Update is called once per frame
	void Update () {
		localVariable = SG.sanity;

		if (localVariable < 0.9f) {
			MainCam.GetComponent<NormalMapDistortion> ().enabled = true;
			MainCam.GetComponent<NormalMapDistortion> ().speedY = localVariable * 3;
			MainCam.GetComponent<NormalMapDistortion> ().speedX = localVariable * 3;

			MainCam.GetComponent<Twirl> ().enabled = true;
			MainCam.GetComponent<Twirl> ().radius.x = 1/localVariable;
			MainCam.GetComponent<Twirl> ().radius.y = 1/localVariable;

			MainCam.GetComponent<NoiseAndScratches> ().enabled = true;
			MainCam.GetComponent<NoiseAndScratches> ().grainSize = 3- (localVariable * 10);

			MainCam.GetComponent<VignetteAndChromaticAberration> ().enabled = true;

			MainCam.GetComponent<Fisheye> ().strengthX = 0.03f / localVariable;
			MainCam.GetComponent<Fisheye> ().strengthY = 0.03f / localVariable;

			MainCam.GetComponent<Bloom> ().bloomIntensity = 0.1f / localVariable * 2;

			MainCam.GetComponent<Headache> ().speed = 1.0f / localVariable / 2;
			MainCam.GetComponent<Headache> ().strength = 1.0f / localVariable / 2;

			MainCam.GetComponent<BloomAndFlares> ().enabled = true;
			MainCam.GetComponent<BloomAndFlares> ().bloomIntensity = 2 - (localVariable * 2);

			MainCam.GetComponent<Tonemapping> ().enabled = true;

		} else {
			
			MainCam.GetComponent<NormalMapDistortion> ().enabled = false;
			MainCam.GetComponent<Headache> ().speed = 0.0f;
			MainCam.GetComponent<Headache> ().strength = 0.0f;
			MainCam.GetComponent<Twirl> ().enabled = false;
			MainCam.GetComponent<NoiseAndScratches> ().enabled = false;
			MainCam.GetComponent<VignetteAndChromaticAberration> ().enabled = false;
			MainCam.GetComponent<BloomAndFlares> ().enabled = false;
			MainCam.GetComponent<Tonemapping> ().enabled = false;


		}
	}
}