using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LosingSanityWhenGettingAway : MonoBehaviour {

	GameObject Player;
	SanityGestion SG;


	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		SG = GameObject.Find ("Player").GetComponent<SanityGestion>();
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(Player.transform.position, transform.position);

		SG.sanity = 1 - (distance /50);
	}
}
