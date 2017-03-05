using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MorePPEffects;

public class AnimDintroUI : MonoBehaviour {

	GameObject cameraMap;
	GameObject ActualCanvas;
	GameObject SanityPanel;
	GameObject Artefact;
	Animator PanelPressSpace;
	bool PressEScript;

	// Use this for initialization
	void Start () {
		cameraMap = GameObject.Find ("CameraMap");
		ActualCanvas = GameObject.Find ("ActualCanvas");
		SanityPanel = GameObject.Find ("SanityPanel");
		Artefact = GameObject.Find ("ARtefactOverLayInteraction");
		PanelPressSpace = GameObject.Find ("PanelPressSpaceAnimator").GetComponent<Animator>();

		Artefact.SetActive (false);
		SanityPanel.SetActive (false);
		ActualCanvas.SetActive (false);
		cameraMap.SetActive (false);

		StartCoroutine ("animIntroUI");
	}
	
	IEnumerator animIntroUI(){
		yield return new WaitForSeconds (5.0f);
		ActualCanvas.SetActive (true);
		PressEScript = false;
		PanelPressSpace.SetBool ("PressE",PressEScript);
		yield return new WaitForSeconds (0.3f);
		ActualCanvas.SetActive (false);

		GameObject.Find ("Main Camera Main").GetComponent<RadialBlur> ().blurStrength = 0.5f;

		yield return new WaitForSeconds (0.2f);

		GameObject.Find ("Main Camera Main").GetComponent<RadialBlur> ().blurStrength = 0.0f;
		ActualCanvas.SetActive (true);
		yield return new WaitForSeconds (0.2f);

		Artefact.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		cameraMap.SetActive (true);
		yield return new WaitForSeconds (0.5f);
		SanityPanel.SetActive (true);
	}
}
