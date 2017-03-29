using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	public string scene;
	public float secToWait = 1.0f;
	public float smoothAmount = 0.1f;

	public bool activateWhite = false;

	public CanvasGroup imageBlanche;

	void OnTriggerEnter (Collider coll)
	{
		if(coll.tag == "Player" && activateWhite == false){
			activateWhite = true;
			StartCoroutine ("waitForLaunching");
		}
	}

	void Update(){
		if (activateWhite) {
			imageBlanche.alpha += smoothAmount;
		}
	}

	IEnumerator waitForLaunching () {
		yield return new WaitForSeconds (secToWait);
		Application.LoadLevel(scene);
	}
}
