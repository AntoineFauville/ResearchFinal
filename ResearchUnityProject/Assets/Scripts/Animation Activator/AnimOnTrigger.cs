using UnityEngine;
using System.Collections;

public class AnimOnTrigger : MonoBehaviour {
	public Animator anim;
	public bool lauchnAnim;

	/*
	public ShackingEffect sE;
	public int secOfAnim;
	public bool didIAllreadyScreenShaked = false;
	*/

	// Update is called once per frame
	void Update () {
		anim.SetBool ("Activate",lauchnAnim);
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			lauchnAnim = true;

			//shaking not working because we would need to change the camera and desactivate camera controller, which makes some error.
			/*if (!didIAllreadyScreenShaked) {
				sE.shake = secOfAnim;
				didIAllreadyScreenShaked = true;
			}*/
		}
	}
}
