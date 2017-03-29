using UnityEngine;
using System.Collections;

public class ChangingViewFocus : MonoBehaviour {

	public GameObject focusActual;
	public GameObject focusPrevious;

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			focusActual.SetActive (true);
			focusPrevious.SetActive (false);
		}
	}
}
