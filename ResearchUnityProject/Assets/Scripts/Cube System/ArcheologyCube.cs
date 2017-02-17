using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class ArcheologyCube : MonoBehaviour {
	/*
	Renderer rend;

	ZoneGestion ZG;

	public float rouge = 0;
	public float vert = 0;



	void Start () {
		rend = GetComponent<Renderer> ();
		ZG = GameObject.Find ("ScriptManager").GetComponent<ZoneGestion> ();
		StartCoroutine ("ColorChange");
	}
	
	// Update is called once per frame
	void Update () {

		rend.material.color = new Color (rouge / 255,vert / 255,0,1);	
	//	float distanceRouge = Vector3.Distance (transform.position, ZG.ListDeZone [0].transform.position);
		float distanceVert = Vector3.Distance (ZG.ListDeZone [0].transform.position, transform.position);

		//print (distanceRouge);

		rouge = Mathf.Round ((distanceRouge / 50.0f) * 255.0f * 2);
		if (rouge < 0.0f) {
			rouge = 0.0f;
		}
		if (rouge > 255.0f) {
			rouge = 255.0f;
		}
		//print ("rouge "+ rouge);
		vert = Mathf.Round (255.0f - (distanceVert / 50.0f) * 255.0f * 2);
		if (vert < 0.0f) {
			vert = 0.0f;
		}
		if (vert > 255.0f) {
			vert = 255.0f;
		}
		//print ("vert " + vert);

	}

	IEnumerator ColorChange (){
		yield return new WaitForSeconds (0.2f);
		rend.material.color = new Color (rouge / 255,vert / 255,0,1);	
		StartCoroutine ("ColorChange");
	}*/
}
