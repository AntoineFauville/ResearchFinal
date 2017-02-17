using UnityEngine;
using System.Collections;

public class RotationCircle : MonoBehaviour {

	public int degree = 45;
	private Vector3 currentRotation;
	public Transform circle;
	public int randbeginning;
	public bool canIUseHorizontalAgain = false;

	void Start ()
	{
		//recupair at the beginning position of the circles
		Quaternion currentRotation = circle.transform.rotation;
		randbeginning = Random.Range (0, 18);
		circle.transform.rotation = currentRotation * Quaternion.Euler (0, 0, randbeginning * 20);
		//circle.transform.rotation = currentRotation * Quaternion.Euler (0, 0, randbeginning);
	}

	void Update () 
	{
		//check for each circle actual position
		Quaternion currentRotation = circle.transform.rotation;

		//rotation of the circles
		if (Input.GetAxis("Horizontal") > 0.5 && canIUseHorizontalAgain == false) {
			circle.transform.rotation = currentRotation * Quaternion.Euler (0, 0, degree);
			canIUseHorizontalAgain = true;
			StartCoroutine ("returnHorizontal");
			//circle.transform.rotation.z += 45;
		}

		if (Input.GetAxis("Horizontal") < -0.5 && canIUseHorizontalAgain == false) {
			circle.transform.rotation = currentRotation * Quaternion.Euler (0, 0, -degree);
			canIUseHorizontalAgain = true;
			StartCoroutine ("returnHorizontal");
			//circle.transform.rotation.z += 45;
		}
	}
	IEnumerator returnHorizontal () {
		yield return new WaitForSeconds (0.1f);
		canIUseHorizontalAgain = false;
	}
}
