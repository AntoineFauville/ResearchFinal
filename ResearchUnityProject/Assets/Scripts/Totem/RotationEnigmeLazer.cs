using UnityEngine;
using System.Collections;

public class RotationEnigmeLazer : MonoBehaviour {

	public int degree = 45;
	private Vector3 currentRotation;
	public Transform part;
	public int randbeginning;
	public bool canIUseHorizontalAgain = false;

	public int startamout = 0;
	public int maxDegreePerAdd = 45;

	public int actualAmoutofDegree;

	public bool amITurningRight = false;
	public bool amITurningLeft = false;

	public bool canIturnAgain = false;

	public bool canIUseIt = false;

	// Use this for initialization
	void Start ()
	{
		//recupair at the beginning position of the parts
		Quaternion currentRotation = part.transform.rotation;
		randbeginning = Random.Range (0, 18);
		part.transform.rotation = currentRotation * Quaternion.Euler (0, randbeginning * 45, 0);
	}
	
	void Update () 
	{
		//check for each parts actual position
		Quaternion currentRotation = part.transform.rotation;

//		print (actualAmoutofDegree);

		if (amITurningRight && canIturnAgain) {
			actualAmoutofDegree += 1;
			part.transform.rotation = currentRotation * Quaternion.Euler (0, degree, 0);
		}

		if (amITurningLeft && canIturnAgain) {
			actualAmoutofDegree += 1;
			part.transform.rotation = currentRotation * Quaternion.Euler (0, -degree, 0);
		}

		if (actualAmoutofDegree >= maxDegreePerAdd) {
			amITurningRight = false;
			amITurningLeft = false;
			canIturnAgain = false;
		}

		//rotation of the parts
		if (Input.GetAxis("Horizontal") > 0.2 && canIUseHorizontalAgain == false && !canIturnAgain && canIUseIt) {
			canIturnAgain = true;
			actualAmoutofDegree = startamout;
			amITurningRight = true;
		}

		if (Input.GetAxis("Horizontal") < -0.2 && canIUseHorizontalAgain == false && !canIturnAgain && canIUseIt) {
			canIturnAgain = true;
			actualAmoutofDegree = startamout;
			amITurningLeft = true;
		}
	}
}


//part.transform.rotation = currentRotation * Quaternion.Euler (0, degree, 0);
//newRotation.rotation = currentRotation * Quaternion.Euler (0, degree, 0);
//print (currentRotation);
//part.transform.rotation = currentRotation * Quaternion.Euler (0, degree, 0);
//Quaternion.Slerp(currentRotation, newRotation.rotation, Time.deltaTime * 0.5f);
//canIUseHorizontalAgain = true;
//tartCoroutine ("returnHorizontal");
//part.transform.rotation = currentRotation * Quaternion.Euler (0, -degree, 0);
//canIUseHorizontalAgain = true;
//StartCoroutine ("returnHorizontal");