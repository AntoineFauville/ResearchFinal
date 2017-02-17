using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddOnceToBar : MonoBehaviour {

	public float amoutGainByThisObject;

	public Image refImage;
	public bool didIAllreadyAteHistory;

	public Animator anim;
	public bool animbool;

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player" && !didIAllreadyAteHistory) {
			didIAllreadyAteHistory = true;
			refImage.fillAmount += amoutGainByThisObject;
			StartCoroutine ("returnBool");
		}
	}

	IEnumerator returnBool () {
		anim.SetBool ("NewObjectiveActiv",animbool);
		animbool = true;
		anim.SetBool ("NewObjectiveActiv",animbool);
		yield return new WaitForSeconds (0.5f);
		anim.SetBool ("NewObjectiveActiv",animbool);
		animbool = false;
		anim.SetBool ("NewObjectiveActiv",animbool);
	}
}