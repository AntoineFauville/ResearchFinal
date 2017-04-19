using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MorePPEffects;

public class AnimDintroUI : MonoBehaviour {

	GameObject 
	cameraMap,
	ActualCanvas,
	SanityPanel,
	Artefact;

	public CanvasGroup whiteCanvas;

	Animator PanelPressSpace;

	bool PressEScript,go;

	float amount;

	// Use this for initialization
	void Awake () {
		amount = 1.0f;
		whiteCanvas.alpha = amount;
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

	void Update(){
		if (go) {
			amount -= 0.01f;
			whiteCanvas.alpha = amount;
		}
		if (amount < 0) {
			go = false;
		}
	}
	
	IEnumerator animIntroUI(){
		yield return new WaitForSeconds (3.0f);
		go = true;
		yield return new WaitForSeconds (2.0f);
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
