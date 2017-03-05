using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class goingUpDown : MonoBehaviour {

	float amout = 0.0f;
	bool goingUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<MeshRenderer> ().shadowCastingMode = ShadowCastingMode.Off;
		this.GetComponent<MeshRenderer> ().material.SetFloat ("_DissolvePercentage", amout);

		if (amout < 1.0f && goingUp) {
			amout += 0.01f;
		} 

		if (amout >= 1.0f && goingUp) {
			goingUp = false;
		}

		if (amout > 0.0f && !goingUp) {
			amout -= 0.01f;
		} 

		if (amout <= 0.0f && !goingUp) {
			goingUp = true;
		}
		


	}
}
