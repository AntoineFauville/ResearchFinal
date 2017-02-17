using UnityEngine;
using System.Collections;

public class RunicPillarA : MonoBehaviour {

	public Animator anim1;
	public Animator anim2;

	public bool one = false;

	void Start () {
		anim1.SetBool ("change", one);
		anim2.SetBool ("change", one);
	}

	void OnTriggerEnter(Collider collider){
		if (collider.tag == "Player" && one == false) {
			one = true;
			anim1.SetBool ("change", one);
			anim2.SetBool ("change", one);
			StartCoroutine("returnBool");
		}
	}

	IEnumerator returnBool () {
		yield return new WaitForSeconds (0.8f);
		one = false;
		anim1.SetBool ("change", one);
		anim2.SetBool ("change", one);
	}
}
