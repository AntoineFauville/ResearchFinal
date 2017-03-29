using UnityEngine;
using System.Collections;

public class RaycastEnigmePrey : MonoBehaviour {

	public GameObject rayTarget;
	public bool didITouched = false;
	public bool delay = false;
	public float delayTime = 2.0f;

	public Vector3 bob;  

	public Animator anim;

	// Use this for initialization
	void Start () {
		StartCoroutine ("delayTimeCorou");
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("DoorOpen", didITouched);

		RaycastHit hit;
		if (Physics.Raycast (transform.position,bob, out hit, 100.0f) && delay && !didITouched)
		{
			Debug.DrawRay (transform.position,bob);
			if(hit.collider.CompareTag("LazerFin")) 
			{
				print ("toutched Damit");
				didITouched = true;
			}
		}
	}

	IEnumerator delayTimeCorou () {
		yield return new WaitForSeconds (delayTime);
		delay = true;
	}
}
