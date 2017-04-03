using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

	//detection des zones.

	DetectableClass[] det;
	public GameObject[] T;

	GameObject 
		RadarSmall,
		Player,
		RadarBig;

	public Animator PanelPressSpace;
	bool PressEScript;

	ArrayList isDetectedAround;

	public float 
	distancePremierCercleDetection = 80.0f, // distancePremierCercleDetection
	distanceChaudFroid = 40.0f,
	distancePressE = 5.0f;

	public bool hotcold;

	float[] distance;

	int pp;

	float DistanceLaPlusProche;

	//systeme chaud froid.

	Animator anim;
//	Animator animArtefact;
	//QT_SurfaceNoise2 QTSurfShad;

	//variable temporaire
	bool didIsendOnceToParticularObject = false;

	//gestion des sons

	//distance longue

	public AudioClip LongueDistanceDetection;

	//chaud froidt
	bool playSoundOnceHC;
	public AudioClip hotColdActivationSound;

	//appuyer sur e

	bool playSoundOncePressE;
	public AudioClip PressESound;

	void Start () {

		//detection des zones

		Player = GameObject.Find ("Player");
		T = GameObject.FindGameObjectsWithTag ("Detectable");

		det = new DetectableClass[T.Length];
		distance = new float[T.Length];

		isDetectedAround = new ArrayList();

		for (int i = 0; i < T.Length; i++) {

			//CircleRadar [i].SetActive (false);

			det [i] = new DetectableClass (
				T [i].transform.position, 
				T [i].name,
				false, false, false);

			//print (T [i].transform.GetChild(0).name);

			T [i].transform.GetChild(0).gameObject.SetActive (false);

			//det [i].Cercle.SetActive (false);
			distance [i] = Vector3.Distance (det [i].pos, Player.transform.position);
			//print (distance [i] + det[i].Name);
		}



		//check si l'objet le plus proche est a moins de distancePremierCercleDetection
		DistanceLaPlusProche = (Mathf.Min (distance));
		//print (Array.IndexOf(distance, Mathf.Min(distance)));

		StartCoroutine ("WaitIntroToStart");

		//systeme chaud froid

	}
	IEnumerator WaitIntroToStart(){
		yield return new WaitForSeconds (7.0f);
		anim =  GameObject.Find ("animartefact_1").GetComponent<Animator>();
	//	animArtefact = GameObject.Find ("artefactNewCanvasChaudFroid").GetComponent<Animator>();
		PanelPressSpace = GameObject.Find ("PanelPressSpaceAnimator").GetComponent<Animator>();
		RadarBig = GameObject.Find ("RadarFeedBackRotationBig");
		RadarSmall = GameObject.Find ("RadarFeedBackRotationSmall");
		RadarBig.SetActive (false);
		RadarSmall.SetActive (false);
		StartCoroutine ("CheckEveryHalfSec");
	}
	IEnumerator CheckEveryHalfSec () {
		yield return new WaitForSeconds (0.1f);

		for (int i = 0; i < T.Length; i++) {



			distance [i] = Vector3.Distance (det [i].pos, Player.transform.position);
			//print (distance [i] + det[i].Name);

			if (distance [i] <= pp) {
				pp = i;
			}



			//check si c'est a moins de distancePremierCercleDetection
			if (distance [i] < distancePremierCercleDetection) {
				if (!isDetectedAround.Contains (det [i])) {
					isDetectedAround.Add (det [i]);
					print ("added smthg to array");
					print (det [i].Name);

					//det [i].isDetectedFarCircle = true;

					//Envoyer au détectable spécifique le fait qu'il a été vu de loin 
					RadarBig.SetActive (true);
					GameObject.Find (det[i].Name).GetComponent<DetectableLocalManager>().ImDetectedFar();
					T[i].transform.GetChild(0).gameObject.SetActive (true);

					//play sound
					AudioSource AS;
					AS = GameObject.Find ("Sound1").GetComponent<AudioSource> ();
					AS.PlayOneShot(LongueDistanceDetection);

					//ajouter a la carte l'info comme quoi un nouvel objet est apparu
					// faire briller l'icone de la map

				}
			}



			if (distance[i] <= distancePressE) {
				GameObject.Find (det[i].Name).GetComponent<DetectableLocalManager>().YouCanPressE(); // dire que le joueur est la



			}

			if (distance[i] > distancePressE) {
				GameObject.Find (det[i].Name).GetComponent<DetectableLocalManager>().ICantPressEAnyMore();
				PressEScript = false;
				PanelPressSpace.SetBool ("PressE", PressEScript);

			}

			//check si c'est a moins de distancePremierCercleDetection


		}

		//calcul chaud froid par rapport a l'objet le plus proche
		DistanceLaPlusProche = (Mathf.Min (distance));
		//print ("array index" + Array.IndexOf(distance, Mathf.Min(distance)));
		//print ("distance plus proche" + DistanceLaPlusProche);
	//	print ("pp" + pp);

		//systeme de chaud froid

		if (DistanceLaPlusProche < distanceChaudFroid) {
			ActiverChaudFroid ();
		} else {
			DesactiverChaudFroid ();
		}

		//systeme lacher le cube
		for (int i = 0; i < T.Length; i++) {
			if (DistanceLaPlusProche < distancePressE && det[Array.IndexOf(distance, Mathf.Min(distance))].hasBeenActivated == false) {
				//global action comme le son
				ActionDisponibleLacherCube ();
				//envoyer au local
			/*} else {
				DesactiverActionDisponibleLacherCube ();*/
			}
		}


		StartCoroutine ("CheckEveryHalfSec");
	}
	//il faut que je check par rapport a la plus proche le chaud froid
	//il faut que je check globalement si une apparait a moins de 50m

	//Systeme chaud froid

	void ActiverChaudFroid()
	{
		if (!playSoundOnceHC) {
			AudioSource AS;
			AS = GameObject.Find ("Sound1").GetComponent<AudioSource> ();
			AS.PlayOneShot(hotColdActivationSound);
			playSoundOnceHC = true;
		}

		RadarSmall.SetActive (true);
		//QTSurfShad.scaleModifier = (distanceChaudFroid - DistanceLaPlusProche)/4;
		//	QTSurfShad.speedModifier = (distanceChaudFroid - DistanceLaPlusProche)/4;
		//QTSurfShad.noiseStrength = (distanceChaudFroid - DistanceLaPlusProche) / distanceChaudFroid/2;

		anim.speed = (distanceChaudFroid - DistanceLaPlusProche) / (distanceChaudFroid/4);
	//	animArtefact.speed = (distanceChaudFroid - DistanceLaPlusProche) / (distanceChaudFroid/4);
	}

	public void DesactiverChaudFroid()
	{
//		animArtefact.speed = 0.0f;
		//QTSurfShad.scaleModifier = 0;
		//QTSurfShad.speedModifier = 0;
		//QTSurfShad.noiseStrength = 0;
		anim.speed = 0.0f;
		RadarSmall.SetActive (false);
		playSoundOnceHC = false;
	}

	//systeme déposer le cube lorsqu'on est dans une zone propice.

	void ActionDisponibleLacherCube()
	{
		//son

			PressEScript = true;
			//PanelPressSpace.SetBool ("PressE",PressEScript);

		/*if (PressEScript == false && GameObject.Find("SmallItem1").GetComponent<Event1>().tutorialFinished == false) {
			PanelPressSpace.SetBool ("PressE",PressEScript);
			PressEScript = true;
			PanelPressSpace.SetBool ("PressE",PressEScript);
		}

		if(PressEScript == false && GameObject.Find("TriggerScript").GetComponent<NewTotem>().totemScript == false) {
			PressEScript = true;
			PanelPressSpace.SetBool ("PressE",PressEScript);
		}*/

		if (!playSoundOncePressE) {
			AudioSource AS;
			AS = GameObject.Find ("Sound1").GetComponent<AudioSource> ();
			AS.PlayOneShot(PressESound);
			playSoundOncePressE = true;
		}
			//bouton "Press E" apparaitre a l'écran

	}

	public void DesactiverActionDisponibleLacherCube()
	{
		/*for (int i = 0; i < T.Length; i++) {
			det [i].hasBeenActivated = true;
		}*/
		for (int i = 0; i < T.Length; i++) {

			det [Array.IndexOf (distance, Mathf.Min (distance))].hasBeenActivated = true;

			if (PressEScript == true) {
				PressEScript = false;
				PanelPressSpace.SetBool ("PressE", PressEScript);
			}
			playSoundOncePressE = false;
			// Bouton press E disparaitre de l'écran
		}
	}

}