using UnityEngine;
using System.Collections;

public class AnimOnTrigger1 : MonoBehaviour {

	public Animator anim1;
	public bool lauchnAnim1;

	bool playerIsHere;
	bool passed;

	// Update is called once per frame
	void Update () {
		anim1.SetBool ("Activate",lauchnAnim1);

		if(playerIsHere && !passed){
			passed = true;
			StartCoroutine ("returnBool");	
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			playerIsHere = true;
		}
	}

	IEnumerator returnBool () {
		lauchnAnim1 = true;
		yield return new WaitForSeconds (1);
		lauchnAnim1 = false;
	}
}
