using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ThirdPersonCamera;

public class pickUpCube : MonoBehaviour {
	/*
	DropCube dc;
	GameObject Player;

	GameObject cubeOnAss;

	OpenCloseBook OCB;

	SanityGestion SG;

	// Use this for initialization
	void Start () {
		dc = GameObject.Find ("Player").GetComponent<DropCube>();
		SG = GameObject.Find ("Player").GetComponent<SanityGestion>();
		Player = GameObject.Find ("Player");
		OCB = GameObject.Find ("ScriptManager").GetComponent<OpenCloseBook> ();
		cubeOnAss = GameObject.Find ("ArtefactOnAss");
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(Player.transform.position, transform.position);

		if (Input.GetButtonDown ("dropcube") && dc.isCubeOnGround && distance < 3 && OCB.isBookOpen == false) {
			SG.sanity = 1;
			//cubeOnAss.SetActive (true);
			dc.StartCoroutine ("returnCubeBool");
			Destroy (this.gameObject);
		}
	}*/
}
