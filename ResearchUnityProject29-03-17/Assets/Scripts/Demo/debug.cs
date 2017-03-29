using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
using UnityStandardAssets.Characters.FirstPerson;

public class debug : MonoBehaviour {

	GameObject player;

	public GameObject[] debugPos;
	int a;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
		debugPos = GameObject.FindGameObjectsWithTag ("debug");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("p")) {
			player.transform.position = debugPos [a].transform.position;
			a++;
		}
		if (a > debugPos.Length - 1) {
			a = 0;
		}
		if (Input.GetKeyDown ("m")) {
			//player.GetComponent<FirstPersonController> ().debugSpeed = 5.0f;
		}

		if (Input.GetKeyDown ("o")) {
			Application.LoadLevel ("MenuScene");
		}
	}
}
