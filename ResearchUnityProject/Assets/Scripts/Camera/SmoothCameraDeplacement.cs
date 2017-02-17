using UnityEngine;
using System.Collections;

public class SmoothCameraDeplacement : MonoBehaviour {

	public Transform target;
	public float smoothTime = 0.3f;
	public Transform origin;
	private Vector3 velocity = Vector3.zero;

	public bool haveIlaunch = false;

	void Update (){
		if (haveIlaunch == false) {
			transform.position = Vector3.SmoothDamp (origin.transform.position, target.transform.position, ref velocity, smoothTime);
			haveIlaunch = true;
		}

		/*if (haveIlaunch == true) {
			transform.position = Vector3.SmoothDamp (target.transform.position,origin.transform.position, ref velocity, smoothTime);
			//haveIlaunch = false;
		}*/
	}
}
