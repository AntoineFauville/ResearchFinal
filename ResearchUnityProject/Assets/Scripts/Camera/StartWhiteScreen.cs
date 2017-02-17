using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartWhiteScreen : MonoBehaviour {

	public CanvasGroup ImageWhite;
	public float smoothWhiteBeginning = 0.05f;
	public bool amIAtZero = false;
	public float secondsBeforeDecreasing = 1.0f;
	private bool launchAnim = false;

	void Start () {
		ImageWhite.alpha = 1.0f;
		StartCoroutine ("secToWaitBeforeWhiteAnim");
	}
	
	// Update is called once per frame
	void Update () {
		if (amIAtZero == false && launchAnim == true) {
			ImageWhite.alpha -= smoothWhiteBeginning;
		}

		if (ImageWhite.alpha <= 0) {
			amIAtZero = true;
		}
	}

	IEnumerator secToWaitBeforeWhiteAnim () {
		yield return new WaitForSeconds (secondsBeforeDecreasing);
		launchAnim = true;
	}
}
