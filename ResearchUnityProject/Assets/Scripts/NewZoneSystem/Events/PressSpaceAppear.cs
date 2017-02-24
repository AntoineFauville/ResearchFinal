using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceAppear : MonoBehaviour {

	DetectableLocalManager DetectL;
	GameObject PanelPressSpace;

	void Start () {
		PanelPressSpace = GameObject.Find ("PanelPressSpace");
		DetectL = this.gameObject.GetComponent<DetectableLocalManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (DetectL.isPlayerHere) {
			PanelPressSpace.SetActive (true);
		} else {
			PanelPressSpace.SetActive (false);
		}
	}
}
