using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndEnigmeRotationCircle : MonoBehaviour {

	public Transform circle1;
	public Transform circle2;
	public Transform circle3;

	public Image img1;
	public Image img2;
	public Image img3;

	public Image imgDoor1;
	public Image imgDoor2;

	public bool isOneTwo = false;
	public bool isTwoThree = false;

	public float initialFillAmout = 0.125f;
	public float finalFillAmout = 0.1f;

	//Quaternion circle1Rotation;
	//Quaternion circle2Rotation;
	//Quaternion circle3Rotation;

	public float secSecondAnimImage;

	// Use this for initialization
	void Start () {
		img1.fillAmount = initialFillAmout;
		img2.fillAmount = initialFillAmout;
		img3.fillAmount = initialFillAmout;

		imgDoor1.fillAmount = initialFillAmout;
		imgDoor1.fillAmount = initialFillAmout;

	/*	circle1Rotation = Quaternion.Euler (0,0,45);
		circle2Rotation = Quaternion.Euler (0,0,0);
		circle3Rotation = Quaternion.Euler (0,0,45);*/
	}
	
	// Update is called once per frame
	void Update () {

		Quaternion currentRotationcircle1 = (circle1.transform.rotation);
		Quaternion currentRotationcircle2 = (circle2.transform.rotation);
		Quaternion currentRotationcircle3 = (circle3.transform.rotation);

		//Debug.Log ("circle2 " + Mathf.Abs(currentRotationcircle2.z));
		//Debug.Log ("circle3 " + Mathf.Abs(currentRotationcircle3.z));

		float rot1 = Mathf.Abs (currentRotationcircle1.z); //0.38
		float rot2 = Mathf.Abs (currentRotationcircle2.z);
		float rot3 = Mathf.Abs (currentRotationcircle3.z);

		//circle1Rotation * Mathf.abs;
		/*print("circle2 " + circle2Rotation);
		print("circle3 " + circle3Rotation);

		print("circle1 " + currentRotationcircle1);
		print("circle2 " + currentRotationcircle2);
		print("circle3 " + currentRotationcircle3);
*/
		//currentRotationcircle1.z *= 360 *= Mathf.PI;

		//print (currentRotationcircle1.z);

		if (rot1 < 0.39f && rot1 > 0.37f && rot2 < 0.01f && rot2 > 0) 
		{
			//print ("Aligned 1 2 ");
			isOneTwo = true;
		}

		if (rot2 < 0.01f && rot2 > 0 && rot3 < 0.39f && rot3 > 0.37f) 
		{
			//print ("Aligned 2 3 ");
			isTwoThree = true;
		}

		if(isOneTwo == true && isTwoThree == true)
		{
			img1.fillAmount += finalFillAmout * Time.deltaTime;
			img2.fillAmount += finalFillAmout * Time.deltaTime;
			img3.fillAmount += finalFillAmout * Time.deltaTime;

			StartCoroutine ("waitforendCircle");
		}
	}

	IEnumerator waitforendCircle () {
		yield return new WaitForSeconds (secSecondAnimImage);
		imgDoor1.fillAmount += finalFillAmout * Time.deltaTime;
		imgDoor2.fillAmount += finalFillAmout * Time.deltaTime;
	}
}
