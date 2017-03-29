using UnityEngine;
using System.Collections;

public class ActivateOnTrigger : MonoBehaviour {

	public Animator anim;
	public GameObject cam1;
	public GameObject mainCam;
	public GameObject Etan1;
	public GameObject Etan2;

	public ShackingEffect shaking;

	public float amount = 5.0f;
	public float amountCam = 7.0f;

	public bool activate;

	void Update () {
		anim.SetBool ("Activ", activate);
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.tag == "Player" && activate == false) {
			mainCam.SetActive (false);
			Etan1.SetActive (false);
			Etan2.SetActive (true);
			cam1.SetActive (true);
			shaking.shake = amount;
			activate = true;

			StartCoroutine ("returnbool");
		}
	}

	IEnumerator returnbool () {
		yield return new WaitForSeconds(amountCam);
		mainCam.SetActive (true);
		cam1.SetActive (false);
		Etan1.SetActive (true);
		Etan2.SetActive (false);
	}
}
