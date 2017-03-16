using UnityEngine;
using System.Collections;

public class RunicPillarA : MonoBehaviour {

	public Animator anim1;
	public Animator anim2;

	public bool one, playerisHere;

	void Start () {
		anim1.SetBool ("change", one);
		anim2.SetBool ("change", one);
	}

	void Update(){
		if (Input.GetButtonDown("Submit") && !one && playerisHere) {
			one = true;
			anim1.SetBool ("change", one);
			anim2.SetBool ("change", one);
			StartCoroutine("returnBool");
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
	}
}
