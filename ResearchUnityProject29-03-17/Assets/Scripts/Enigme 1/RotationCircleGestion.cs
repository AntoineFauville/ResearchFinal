using UnityEngine;
using System.Collections;

public class RotationCircleGestion : MonoBehaviour {

	public GameObject circle1;
	public GameObject circle2;
	public GameObject circle3;

	public GameObject circle1Outline;
	public GameObject circle2Outline;
	public GameObject circle3Outline;

	public bool state1; // small circle
	public bool state2; // middle circle
	public bool state3; // big circle

	public bool CanIUseVerticalAgain = false;

	// Use this for initialization
	void Start () {
		state1 = false;
		state2 = false;
		state3 = true;
	}
	
	// Update is called once per frame
	void Update () {

		//what circle is active
		//to make sure one circle is activated at once
		if (state1 == true) 
		{
			circle1.SetActive(true);
			circle2.SetActive(false);
			circle3.SetActive(false);

			circle1Outline.SetActive(true);
			circle2Outline.SetActive(false);
			circle3Outline.SetActive(false);
		}
		if (state2 == true) 
		{
			circle1.SetActive(false);
			circle2.SetActive(true);
			circle3.SetActive(false);

			circle1Outline.SetActive(false);
			circle2Outline.SetActive(true);
			circle3Outline.SetActive(false);
		}
		if (state3 == true) 
		{
			circle1.SetActive(false);
			circle2.SetActive(false);
			circle3.SetActive(true);

			circle1Outline.SetActive(false);
			circle2Outline.SetActive(false);
			circle3Outline.SetActive(true);
		}

		//by assuming that state3 is active from the beginning

		//switch from circle to an other

		if(state1 == true && Input.GetAxis("Vertical") < -0.5 && CanIUseVerticalAgain == false && 
			(circle1.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle2.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle3.GetComponent<RotationCircle>().canIUseHorizontalAgain == false))
		{
			state1 = false;
			state2 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
		else if(state2 == true && Input.GetAxis("Vertical") < -0.5 && CanIUseVerticalAgain == false && 
			(circle1.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle2.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle3.GetComponent<RotationCircle>().canIUseHorizontalAgain == false))
		{
			state2 = false;
			state3 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
		if(state2 == true && Input.GetAxis("Vertical") > 0.5 && CanIUseVerticalAgain == false && 
			(circle1.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle2.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle3.GetComponent<RotationCircle>().canIUseHorizontalAgain == false))
		{
			state2 = false;
			state1 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
		else if(state3 == true && Input.GetAxis("Vertical") > 0.5 && CanIUseVerticalAgain == false && 
			(circle1.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle2.GetComponent<RotationCircle>().canIUseHorizontalAgain == false) && 
			(circle3.GetComponent<RotationCircle>().canIUseHorizontalAgain == false))
		{
			state3 = false;
			state2 = true;
			CanIUseVerticalAgain = true;
			StartCoroutine ("waitForVerticalInput");
		}
	}

	IEnumerator waitForVerticalInput () {
		yield return new WaitForSeconds (0.3f);
		CanIUseVerticalAgain = false;
	}
}
