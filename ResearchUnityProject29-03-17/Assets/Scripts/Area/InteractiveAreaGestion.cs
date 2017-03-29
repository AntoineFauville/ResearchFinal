using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractiveAreaGestion : MonoBehaviour {

	public Image imageInteractive;

	public bool didIResolveEnigma1;
	public bool didIResolveEnigma2;

	public GameObject LazerFinal;

	public Animator animMiddle;
	public bool go;

	// Use this for initialization
	void Start () {
		LazerFinal.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		animMiddle.SetBool ("GO",go);

		if (didIResolveEnigma1 && didIResolveEnigma2) {
			go = true;
			LazerFinal.SetActive (true);
		}
	}
}
