using UnityEngine;
using System.Collections;

public class WhenWalkedActivateMontage : MonoBehaviour {

	public bool montageOn;
	public Animator anim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("Reconstitue",montageOn);
	}
	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			montageOn = true;
		}
	}
}
