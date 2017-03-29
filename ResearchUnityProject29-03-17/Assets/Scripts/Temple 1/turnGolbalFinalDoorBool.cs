using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnGolbalFinalDoorBool : MonoBehaviour {

	public BookapintuOpenTheGate bookapitu;

	public bool enigma1;
	public bool enigma2;
	public bool enigma3;

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player" && enigma1) {
			bookapitu.enigma1DoneB = true;
		} else if (coll.tag == "Player" && enigma2) {
			bookapitu.enigma2DoneB = true;
		} else if (coll.tag == "Player" && enigma3) {
			bookapitu.enigma3DoneB = true;
		}
	}
}
