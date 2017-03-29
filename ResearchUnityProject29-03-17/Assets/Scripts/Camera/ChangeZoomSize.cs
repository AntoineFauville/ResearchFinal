using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ThirdPersonCamera
{
public class ChangeZoomSize : MonoBehaviour {

		public CameraController CC;
		public LockOnTarget LockTargetScript;

		public GameObject OtherTrigger; //allways by two

		public bool activate = false;

		public bool triggerDeZomm = false;
		public bool triggerZoom = false;


		//hard focus
		public bool shouldIFocusSmthg = false;
		public float secondOfHardFocus = 1.0f;
		public bool amIHardFocusing = false;

		public float smooth = 0.01f;

		public float oldDistance = 2.5f;
		public float newDistance = 15.0f;

	// Use this for initialization
		void Start () {
		}
	
	// Update is called once per frame
		void Update () {
			//Zoom Gestion
			if (activate){
				if((oldDistance > newDistance) && triggerZoom){
					CC.desiredDistance -= smooth;
				}
				if((oldDistance < newDistance) && triggerDeZomm){
					CC.desiredDistance += smooth;
				}
			}
			if ((CC.desiredDistance >= newDistance) && triggerDeZomm){
				activate = false;
			} else if ((CC.desiredDistance <= newDistance) && triggerZoom){
				activate = false;
			}

			//hard Focus
			if (shouldIFocusSmthg) {
				if (amIHardFocusing){
					LockTargetScript.hardFocus = true;
					StartCoroutine ("returnHardFocus");
				}
			}
		}

		void OnTriggerEnter (Collider coll) {
			if (coll.tag == "Player") {
				// une est pour le zoom
				activate = true;
				//l'autre est pour le hard focus, activate doit rester true tout le long, 
				//jusqu'a la fin de mon zoom tandis que amIHardFocus doit se reset après 2 sec, 
				//raison pour laquelle je ne prend pas activate pour le hard focus
				amIHardFocusing = true;

				StartCoroutine ("ActivateOtherTrigger");
			}
		}
		//coroutine hard focus
		IEnumerator returnHardFocus (){
			yield return new WaitForSeconds (secondOfHardFocus);
			amIHardFocusing = false;
			LockTargetScript.hardFocus = false;
		}

		//coroutine zoom
		IEnumerator ActivateOtherTrigger () {
			yield return new WaitForSeconds (2.0f);
			OtherTrigger.SetActive (true);
			yield return new WaitForSeconds (secondOfHardFocus - 1.0f);
			gameObject.SetActive (false);
		}
	}
}
