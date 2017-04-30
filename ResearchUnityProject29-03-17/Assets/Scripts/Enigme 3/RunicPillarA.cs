using UnityEngine;
using System.Collections;

public class RunicPillarA : MonoBehaviour {

	public Animator 
	anim1,
	anim2,
	boutonAnim;

	public bool 
	one,
	playerisHere,
	isItOne,
	isItTwo,
	isItThree,
	isItFour;

	public EnigmeManager EM;

	void Start () {
		anim1.SetBool ("change", one);
		anim2.SetBool ("change", one);
	}

	void Update(){
		if (Input.GetButtonDown("E") && !one && playerisHere) {
			one = true;
			anim1.SetBool ("change", one);
			anim2.SetBool ("change", one);
			
			boutonAnim.SetBool ("act", one);

			StartCoroutine("returnBool");

			if (isItOne) {
				EM.IncrementOne ();
			}
			if (isItTwo) {
				EM.IncrementTwo ();
			}
			if (isItThree) {
				EM.IncrementThree ();
			}
			if (isItFour) {
				EM.IncrementFour ();
			}
		}
	}

	void OnTriggerEnter (Collider collider){
		if (collider.tag == "Player") {
			playerisHere = true;
		}
	}

	void OnTriggerExit (Collider collider){
		if (collider.tag == "Player") {
			playerisHere = false;
		}
	}

	IEnumerator returnBool () {
		yield return new WaitForSeconds (0.5f);
		one = false;
		anim1.SetBool ("change", one);
		anim2.SetBool ("change", one);
		boutonAnim.SetBool ("act", one);
	}
}
