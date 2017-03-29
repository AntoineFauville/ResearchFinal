using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class CircleOpeningAfterEndRotation : MonoBehaviour {

	public Transform leftDoor;
	public Transform RightDoor;

	public Vector3 leftDoorTransform;
	public Vector3 RightDoorTransform;

	public Vector3 finalleftDoorTransform;
	public Vector3 finalRightDoorTransform;

	public float secToOpenDoor;
	public float secOfOpenningDoor;

	public bool isDoorOpening = false;
	public bool haveIPlayedOnce = false;

	public bool canImoveAfterAnimationOfDoorOpening = false;

	public EndEnigmeRotationCircle EERC;

	// Use this for initialization
	void Start () {
		leftDoorTransform = leftDoor.transform.position;
		RightDoorTransform = RightDoor.transform.position;  
	}
	
	// Update is called once per frame
	void Update () {
		if (EERC.isOneTwo == true && EERC.isTwoThree == true && haveIPlayedOnce == false){
			StartCoroutine ("WaitToOpenTheGate");
			haveIPlayedOnce = true;
		}

		if (isDoorOpening == true) {
			leftDoor.transform.position -= finalleftDoorTransform;
			RightDoor.transform.position -= finalRightDoorTransform;
		}
	}

	IEnumerator WaitToOpenTheGate (){
		yield return new WaitForSeconds (secToOpenDoor);
		GameObject.Find ("CameraEnigme").GetComponent<Camera> ().enabled = false;
		GameObject.Find ("Main Camera Main UI").GetComponent<Camera> ().enabled = true;
		GameObject.Find ("Main Camera Main").GetComponent<Camera> ().enabled = true;
		GameObject.Find ("Player").GetComponent<FirstPersonController> ().enabled = true;
		GameObject.FindGameObjectWithTag ("cameraMapRes").GetComponent<Camera> ().enabled = true;
		isDoorOpening = true;
		StartCoroutine ("StopTheGate");
	}

	IEnumerator StopTheGate () {
		yield return new WaitForSeconds (secOfOpenningDoor);
		isDoorOpening = false;
		canImoveAfterAnimationOfDoorOpening = true;
	}
}
