using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpaceAppear : MonoBehaviour {

	DetectableLocalManager DetectL;
	GameObject PanelPressSpace;

	bool state;

	void Start () {
		/*PanelPressSpace = GameObject.Find ("PanelPressSpace");
		DetectL = this.gameObject.GetComponent<DetectableLocalManager> ();*/
	}
	
	// Update is called once per frame
	void Update () {
		/*if (DetectL.isPlayerHere == true && !state) {
			PanelPressSpace.SetActive (true);
			state = true;
		} else if (DetectL.isPlayerHere == false && state) {
			PanelPressSpace.SetActive (false);
			state = false;
		}*/
	}
}
