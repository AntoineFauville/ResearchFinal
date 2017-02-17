using UnityEngine;
using System.Collections;

public class InstantiatePrefabOnWalk : MonoBehaviour {

	public GameObject PrefabSmall;

	public float secWaitInstatiateSmallStep = 0.1f;
	public float secWaitInstatiateBigStep = 0.05f;
	public bool didIInstantiateSmall = false;
	public bool didIInstantiateBig = false;

	public float SecondForJumping = 0.5f;

	public bool jumpIsOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//up
		if(Input.GetButtonDown("Jump") && jumpIsOn == false){
			jumpIsOn = true;
			StartCoroutine ("JumpIsOnNow");
		}
		if (jumpIsOn == false) {
			if (Input.GetAxis ("Vertical") > 0.4 && Input.GetAxis ("Vertical") < 0.7 && didIInstantiateSmall == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateSmall = true;
				StartCoroutine ("returnValueOn");
			} else if (Input.GetAxis ("Vertical") > 0.71 && Input.GetAxis ("Vertical") <= 1 && didIInstantiateBig == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateBig = true;
				StartCoroutine ("returnValueOntwo");
			}
			//down
			if (Input.GetAxis ("Vertical") < -0.4 && Input.GetAxis ("Vertical") > -0.7 && didIInstantiateSmall == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateSmall = true;
				StartCoroutine ("returnValueOn");
			} else if (Input.GetAxis ("Vertical") < -0.71 && Input.GetAxis ("Vertical") >= -1 && didIInstantiateBig == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateBig = true;
				StartCoroutine ("returnValueOntwo");
			}
			//left
			if (Input.GetAxis ("Horizontal") > 0.4 && Input.GetAxis ("Horizontal") < 0.7 && didIInstantiateSmall == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateSmall = true;
				StartCoroutine ("returnValueOn");
			} else if (Input.GetAxis ("Horizontal") > 0.71 && Input.GetAxis ("Horizontal") <= 1 && didIInstantiateBig == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateBig = true;
				StartCoroutine ("returnValueOntwo");
			}
			//right
			if (Input.GetAxis ("Horizontal") < -0.4 && Input.GetAxis ("Horizontal") > -0.7 && didIInstantiateSmall == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateSmall = true;
				StartCoroutine ("returnValueOn");
			} else if (Input.GetAxis ("Horizontal") < -0.71 && Input.GetAxis ("Horizontal") >= -1 && didIInstantiateBig == false) {

				Instantiate (PrefabSmall, transform.position, transform.rotation);

				didIInstantiateBig = true;
				StartCoroutine ("returnValueOntwo");
			}
		}
	}

	IEnumerator returnValueOn () {
		yield return new WaitForSeconds (secWaitInstatiateSmallStep);
		didIInstantiateSmall = false;
	}

	IEnumerator returnValueOntwo () {
		yield return new WaitForSeconds (secWaitInstatiateBigStep);
		didIInstantiateBig = false;
	}

	IEnumerator JumpIsOnNow () {
		yield return new WaitForSeconds (SecondForJumping);
		jumpIsOn = false;
	}
}
