using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateCanvasWhenPassNearBy : MonoBehaviour {

	public CanvasGroup panel;
	public float smoothAppearing = 0.03f;

	public bool haveIPassed = false;
	// Use this for initialization
	void Start () {
		panel.alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(haveIPassed){
			panel.alpha += smoothAppearing;
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			haveIPassed = true;
		}
	}
}
